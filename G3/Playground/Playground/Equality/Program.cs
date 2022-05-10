// See https://aka.ms/new-console-template for more information
using Equality;

Console.WriteLine("Hello, World!");

var w1 = new Person
{
    FirstName = "Wekoslav",
    LastName = "Stefanovski"
};

var w2 = new Person
{
    FirstName = "Wekoslav",
    LastName = "Stefanovski"
};

Console.WriteLine(w1 == w2);

Console.WriteLine(w1.Equals(w2));

Console.WriteLine(string.Empty.PadLeft(20, '-'));
//-------------

var w3 = new PersonStruct
{
    FirstName = "Wekoslav",
    LastName = "Stefanovski"
};

var w4 = new PersonStruct
{
    FirstName = "Wekoslav",
    LastName = "Stefanovski"
};

// Console.WriteLine(w3 == w4);

Console.WriteLine(w3.Equals(w4));

Console.WriteLine(string.Empty.PadLeft(20, '-'));
//-------------

var w5 = new PersonRecord("Wekoslav", "Stefanovski");


var w6 = new PersonRecord("Wekoslav", "Stefanovski");


Console.WriteLine(w5 == w6);

Console.WriteLine(w5.Equals(w6));

Console.WriteLine(w1);

