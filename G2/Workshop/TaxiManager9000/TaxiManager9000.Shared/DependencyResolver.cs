using TaxiManager9000.DataAccess;
using TaxiManager9000.DataAccess.Interface;

namespace TaxiManager9000.Shared
{
    public static class DependencyResolver
    {
        private static Dictionary<Type, object> _dependencies = new Dictionary<Type, object>()
        {
            { typeof(IUserDatabase), new UserDatabase() },
            { typeof(ICarDatabase), new CarDatabase() },
            { typeof(IDriverDatabase), new DriverDatabase() }
        };


        public static T GetService<T>()
        {
            return (T)_dependencies[typeof(T)];
        } 
    }
}