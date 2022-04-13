namespace CSharpAdvanced_G2_L2_StaticClasses_EX1.Entities
{
    public class User
    {
        public const int USERNAME_MAX_LENGTH = 255;

        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }
    }
}
