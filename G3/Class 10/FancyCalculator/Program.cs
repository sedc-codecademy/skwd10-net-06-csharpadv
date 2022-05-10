using FancyCalculator;

Console.WriteLine("Hello world");

var calc = new Calculator();

var op = new Operation
{
    Value = "Exp",
    Symbol = "^"
};

calc.AddOperation(op, (f, s) => (int)Math.Pow(f, s));

//Console.WriteLine(calc.Execute(2, 5, op));

calc.AddOperation(Operation.Invalid, (f, s) =>
{
    Console.WriteLine("Invalid operation");
    throw new ApplicationException("Invalid operation");
});


//Operation.Add


var reader = new ConsoleReader();
var first = reader.ReadInteger();
var second = reader.ReadInteger();
var op2 = reader.ReadOperation(calc);

var result = calc.Execute(first, second, op2);

Console.WriteLine(result);