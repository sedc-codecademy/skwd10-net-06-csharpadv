namespace CharpAdvanced_G2_L1_Interfaces_EX1.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }

        string Name { get; set; }
    
        string Username { get; set; }

        string Password { get; set; }

        void PrintUser();
    }
}
