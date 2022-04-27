#region Methods
void SayWhatever(string whatever, SayDelegate sayDel)
{
    Console.WriteLine("Chatbot says:");
    sayDel(whatever);
}
void NumberMaster(int num1, int num2, NumbersDelegate numbersDel)
{
    Console.WriteLine($"The result is: {numbersDel(num1, num2)}");
}
void SayHello(string person)
{
    Console.WriteLine($"Hello {person}");
}
void SayBye(string person)
{
    Console.WriteLine($"Bye {person}");
}
#endregion

#region Instantiating a delegate with method
SayDelegate del = new SayDelegate(SayHello); // The SayDelegate points to SayHello
SayDelegate bye = new SayDelegate(SayBye); // The SayDelegate points to SayBye
SayDelegate wow = new SayDelegate(x => Console.WriteLine($"Wow {x}!")); // The SayDelegate points to an anonymous method

del("Bob");
bye("Jill");
wow("Greg");
#endregion

#region Passing a method to a delegate parameter
SayWhatever("Bob", SayHello);
SayWhatever("Bob", bye);
SayWhatever("Jill", SayBye);
SayWhatever("Greg", x => Console.WriteLine($"Wow {x}!"));
SayWhatever("Anne", x =>
{
    Console.WriteLine($"Stuff with {x}");
    Console.WriteLine($"Other stuff with {x}");
});
#endregion

#region Making a high order method
Console.WriteLine("Number master! It is really master at numbers!");
NumberMaster(2, 5, (x, y) => x + y);
NumberMaster(2, 5, (x, y) => x - y);
NumberMaster(2, 5, (x, y) => 0);
NumberMaster(13, 5, (x, y) => x / y);
NumberMaster(2, 5, (x, y) =>
{
    if (x > y) return x;
    return y;
});

#endregion

// Declaring delegate
// This is the signature of any method that we want this delegate to point to
delegate void SayDelegate(string something);
delegate int NumbersDelegate(int num1, int num2);
