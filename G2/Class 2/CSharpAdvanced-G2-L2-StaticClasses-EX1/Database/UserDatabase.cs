using CSharpAdvanced_G2_L2_StaticClasses_EX1.Entities;

namespace CSharpAdvanced_G2_L2_StaticClasses_EX1.Database
{
    public static class UserDatabase
    {
        public static List<User> USERS = new List<User>()
        {
            new User("Miki"),
            new User("Dragan"),
            new User("Bojan"),
            new User("Dimitar"),
        };
    }
}
