namespace CSharpAdvanced_G2_L1_Interfaces.Entities
{
    public abstract class User
    {
        public string Name { get; set; }

        protected User(string name)
        {
            Name = name;
        }
    }
}
