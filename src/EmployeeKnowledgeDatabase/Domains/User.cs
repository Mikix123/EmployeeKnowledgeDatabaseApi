using System;
using Microsoft.AspNetCore.Identity;

namespace EmployeeKnowledgeDatabase.Domains
{
    public class User
    {

        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsEnabled { get; set; }

        public string Role { get; set; }


        public bool ValidatePassword(string password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(this, Password, password) != PasswordVerificationResult.Failed;

        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            Password = passwordHasher.HashPassword(this, password);
        }

    }
}