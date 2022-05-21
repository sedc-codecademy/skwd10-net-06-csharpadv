namespace TaxiManager9000.Domain
{
    public class User : BaseEntity
    {
        public User() { }
        public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
        private string _username;
        public string Username
        {
            get => _username;
            set => _username = value.ToLower();
        }
        public string Password { get; set; }
        public Role Role { get; set; }

        public override string Print()
        {
            return $"{Username} with the role of {Role}!";
        }
    }
}
