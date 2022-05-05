using Class07.Demo.Entities;
//DELEGATES
#region Methods
void SayWhatever(string whatever, SayDelegate sayDel)
{
    Console.Write("Chatbot says:");
    sayDel(whatever);
}
void NumberMaster(int num1, int num2, NumbersDelegate numberDel)
{
    Console.WriteLine($"The result is: {numberDel(num1, num2)}");
}
void SayHello(string person)
{
    Console.WriteLine($"Hello {person}!");
}
void SayBye(string person)
{
    Console.WriteLine($"Bye {person}!");
}

void Say10Times(int count)
{

}
#endregion

#region Instantiating a delegate with methods
SayDelegate del = new SayDelegate(SayHello); // The SayDelegate points to SayHello
SayDelegate bye = new SayDelegate(SayBye); // The SayDelegate points to SayBye
SayDelegate wow = new SayDelegate(x => Console.WriteLine($"Wow {x}!")); // The SayDelegate points to an anonymous method

// Using the delegate ( Points to methods )
del("Bob");
bye("Jill");
wow("Greg");
#endregion

#region Passing a method to a delegate parameter
SayWhatever("Bob", SayHello);
SayWhatever("Jill", SayBye);
SayWhatever("Greg", x => Console.WriteLine($"Wow {x}!"));
SayWhatever("Anne", x =>
{
    Console.WriteLine($"Stuff with {x}");
    Console.WriteLine($"Other stuff with {x}");
});
#endregion

#region Making a high order method
Console.WriteLine("NUMBER MASTER! IT IS REALLY MASTER AT NUMBERS!");
NumberMaster(2, 5, (x, y) => x + y);
NumberMaster(2, 5, (x, y) => x - y);
NumberMaster(2, 5, (x, y) => 0);
NumberMaster(2, 5, (x, y) =>
{
    if (x > y) return x;
    return y;
});
#endregion


//Publisher/Subscriber model
#region Event, Delegate, Publisher/Subscriber
Publisher publisher = new Publisher();
Subscriber subscriber = new Subscriber();
Subscriber subscriber3 = new Subscriber();
Subscriber subscriber4 = new Subscriber();
Subscriber2 subscriber2 = new Subscriber2();

//subsccribe to events that we want to receive info about
publisher.DataProcessingHandler += subscriber.PrintMessage;
publisher.DataProcessingHandler += subscriber2.PrintMessage;
publisher.DataProcessingHandler += subscriber3.PrintMessage;
publisher.DataProcessingIntHandler += subscriber4.PrintMessageInt;
publisher.DataProcessingIntHandler += subscriber3.PrintMessageInt;

//Process data in the publisher and notify all subscribed to events
publisher.ProcessData("Procesiram mnogu podatoci.");
publisher.ProcessInt(5);

Console.ReadLine();
//unsubscribe from events
publisher.DataProcessingHandler -= subscriber3.PrintMessage;
publisher.DataProcessingIntHandler -= subscriber4.PrintMessageInt;

//Process data in the publisher and notify all subscribed to events
publisher.ProcessData("Procesiram mnogu podatoci 2.");
publisher.ProcessInt(5);
#endregion

// Declaring delegates
// This is the signature of any method that we want this delegate to point to
delegate void SayDelegate(string something);
delegate int NumbersDelegate(int num1, int num2);