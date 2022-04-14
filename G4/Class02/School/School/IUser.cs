namespace School
{
    /// <summary>
    /// A general purpose interface for modelling users
    /// </summary>
    internal interface IUser
    {
        string Id { get; set; }
        string Name { get; set; }
        string UserName { get; set; }
        string Password { get; set; }

        void PrintUser();
    }
}
