using Class08.TaxiManager9000.Domain.Enums;

namespace Class08.TaxiManager9000.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }

        public User(string username, string password, RoleEnum role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
        public override string Print()
        {
            return $"User {Id} - {Username} and role {Role}";
        }
    }
}
