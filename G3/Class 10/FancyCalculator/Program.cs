using FancyCalculator;

Console.WriteLine("Hello world");

var calc = new Calculator();

var op = new Operation
{
    Value = "Exp"
};

calc.AddOperation(op, (f, s) => (int)Math.Pow(f, s));

Console.WriteLine(calc.Execute(2, 5, op));


//Operation.Add