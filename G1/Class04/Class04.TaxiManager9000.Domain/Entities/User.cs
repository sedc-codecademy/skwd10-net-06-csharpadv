using Class04.TaxiManager9000.Domain.Enums;

namespace Class04.TaxiManager9000.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }

        public User (string username, string password, RoleEnum role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
        public override string Print()
        {
            return $"User with username {Username} and role {Role}";
        }
    }
}
