namespace Class14.Demo1.Practices
{
    //bad example
    public class naming
    {
        private string privateString { get; set; }
        public string publicstring { get; set; }

        public string Getalldata()
        {
            string Name = "Riki";
            return Name;
         }
    }

    public class NamingCoinvention
    {
        private string _privateString { get; set; }
        public string PublicString { get; set; }

        public string GetAllData()
        {
            return _privateString + PublicString;
        }
    }

    //bad example
    public class LoginProblem : Exception
    {
        //code to handle login exception
    }

    //good example
    public class LoginException : Exception
    {
        //code to handle login exception
    }

    //bad
    public interface LoginService
    {

    }

    public interface ILoginService
    {
        
    }
}
