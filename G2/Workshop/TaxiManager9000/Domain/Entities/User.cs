using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class User
    {
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
            Id = -1;
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}
