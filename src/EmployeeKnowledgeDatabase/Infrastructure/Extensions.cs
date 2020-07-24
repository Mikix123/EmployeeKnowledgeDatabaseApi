using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace EmployeeKnowledgeDatabase.Infrastructure
{
    public static class Extensions
    {
        public static long ToTimestamp(this DateTime dateTime)
        {
            var centuryBegin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            var expectedDate = dateTime.Subtract(new TimeSpan(centuryBegin.Ticks));

            return expectedDate.Ticks / 10000;
        }

        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);

            return model;
        }

        public static T Bind<T>(this T model, Expression<Func<T, object>> expression, object value)
            => model.Bind<T, object>(expression, value);

        private static TModel Bind<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression,
            object value)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            var propertyName = memberExpression.Member.Name.ToLowerInvariant();
            var modelType = model.GetType();
            var field = modelType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .SingleOrDefault(x => x.Name.ToLowerInvariant().StartsWith($"<{propertyName}>"));
            if (field == null)
            {
                return model;
            }

            field.SetValue(model, value);

            return model;
        }
    }
}