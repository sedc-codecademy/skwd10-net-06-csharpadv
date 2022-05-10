using Class09.Example1.Services;

namespace Class09.Example1.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        private int _age { get; set; }

        public int Age 
        { 
            get
            {
                return _age;
            }
            set
            {
                if (value < 0) throw new InvalidUserPropertyException();
                _age = value;
            }
        }
    }
}
