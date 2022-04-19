using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class User
    {
        private const int USERNAME_MIN_LENGTH = 5;

        private const int PASSWORD_MIN_LENGTH = 5;

        public int Id { get; set; }

        public string UserName { get; set; }
    
        public string Password { get; set; }  

        public Role Role { get; set; }

        /// <summary>
        /// When creating a new user, which has not been added to the database
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        public User(string userName, string password, Role role)
        {
            if (userName.Length < USERNAME_MIN_LENGTH)
            {
                throw new ArgumentOutOfRangeException($"The username must be longer than {USERNAME_MIN_LENGTH} charracters");
            }

            ValidatePassword(password);

            Id = -1;
            UserName = userName;
            Password = password;
            Role = role;
        }

        private static void ValidatePassword(string password)
        {
            if (password.Length < PASSWORD_MIN_LENGTH)
            {
                throw new ArgumentOutOfRangeException($"The password must be longer than {PASSWORD_MIN_LENGTH} charracters");
            }

            if (!password.Any(char.IsDigit))
            {
                throw new ArgumentOutOfRangeException($"The password must contain at least one number");
            }
        }
    }
}
