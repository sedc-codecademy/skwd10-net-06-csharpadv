namespace GoodPractices
{
    // always prefix interfaces with a capital 'I'
    public interface IEntityService
    {
        // service methods are a good way to wrap common logic
        // that goes together and is a part of some business process
        // instead of putting it directly into the executing/UI project
        // as separate lines. This allows better maintainability and
        // reusability. In the context of a service layer, however, don't
        // abuse this, and make sure that you do not "leak" anything from
        // the other layers depending on the service layer (usually the UI
        // layer) because in that case you won't get the benefits of a
        // layered architecture and potentially make the application less
        // maintainable because of wrong dependencies
        void DoSomething();

        // avoid methods with too many parameters - too many parameters is
        // usually a symptom that you are doing too many things with the
        // method; either split it to multiple smaller methods so you have
        // proper single responsibility for each split part, or consider
        // wrapping the parameters into a separate class and send only a
        // single instance of that class instead
        void MethodWithTooManyParameters(string param1, string param2, string param3, string param4, string param5,
            string param6, string param7, string param8, string param9, string param10, string param11, string param12,
            string param13, string param14, string param15, string param16, string param17, string param18,
            string param19, string param20);
    }
}