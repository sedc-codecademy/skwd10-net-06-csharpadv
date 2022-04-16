using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }
    
        public string Password { get; set; }  

        public Role Role { get; set; }

        public User(int id, string userName, string password, Role role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}
