using TaxiManager9000.DataAccess;
using TaxiManager9000.DataAccess.Interface;

namespace TaxiManager9000.Shared
{
    public static class DepencyResolver
    {
        private static Dictionary<Type, object> _dependencies = new Dictionary<Type, object>()
        {
            { typeof(IUserDatabase), new UserDatabase() }
        };


        public static T GetService<T>()
        {
            return (T)_dependencies[typeof(T)];
        } 
    }
}