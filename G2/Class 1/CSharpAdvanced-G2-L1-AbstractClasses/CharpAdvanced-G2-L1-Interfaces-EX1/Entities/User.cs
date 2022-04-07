using CharpAdvanced_G2_L1_Interfaces_EX1.Interfaces;

namespace CharpAdvanced_G2_L1_Interfaces_EX1.Entities
{
    public abstract class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        protected User(int id, string name, string username, string password)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
        }

        public virtual void PrintUser()
        {
            Console.WriteLine($"{Id} {Name} {Username}");
        }
    }
}
