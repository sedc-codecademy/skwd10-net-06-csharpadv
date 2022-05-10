namespace FancyCalculator
{
    internal interface ICalculator
    {
        void AddOperation(Operation op, Func<int, int, int> function);
        int Execute(int first, int second, Operation op);
        Operation Resolve(string symbol);
    }
}