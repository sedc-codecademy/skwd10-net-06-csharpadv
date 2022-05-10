using FileManager;

var reader = new ConsoleReader();
var first = reader.ReadInteger();
var second = reader.ReadInteger();
var op = reader.ReadOperation();

var result = Calculate.Execute(first, second, op);

Console.WriteLine(result);

