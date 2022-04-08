namespace School
{
    /// <summary>
    /// An interface for modelling students
    /// </summary>
    internal interface IStudent // : IUser
    {
        List<int> Grades { get; set; }
    }
}
