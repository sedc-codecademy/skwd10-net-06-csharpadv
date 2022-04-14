namespace School
{
    internal abstract class User : IUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public abstract void PrintUser();
    }
}
