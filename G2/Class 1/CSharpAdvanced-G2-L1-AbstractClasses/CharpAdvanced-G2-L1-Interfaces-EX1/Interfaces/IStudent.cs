namespace CharpAdvanced_G2_L1_Interfaces_EX1.Interfaces
{
    public interface IStudent : IUser
    {
        List<int> Grades { get; set; }
    }
}
