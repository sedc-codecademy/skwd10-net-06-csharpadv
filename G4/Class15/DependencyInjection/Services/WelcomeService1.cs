namespace DependencyInjection.Services
{
    public class WelcomeService1 : IWelcomeService
    {
        public string GetWelcomeMessage()
        {
            return "Hi SEDC from WelcomeService1!";
        }
    }
}
