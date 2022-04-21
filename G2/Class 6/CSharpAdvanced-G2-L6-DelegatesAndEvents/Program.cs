// See https://aka.ms/new-console-template for more information

SayHelloTo method = (string personName) =>
{ 
    Console.WriteLine(personName); 
};

//method.Invoke("Miki");

method = (string personName) => { Console.WriteLine(personName + " From Annonymous Method!"); };

//method.Invoke("Bojan");

GreetName("Miki", method);

DoMath doMath = (int numberOne, int numberTwo) =>
{
    return numberOne + numberTwo;
};


method = new SayHelloTo(SayHelloTo);

method("Dragan");

int result = doMath(1, 2);

Console.WriteLine(result);

doMath = (int numberOne, int numberTwo) =>
{
    return numberOne * numberTwo;
};

Console.WriteLine(doMath(2, 2));

void GreetName(string personName, SayHelloTo method)
{
    method.Invoke(personName);
    Console.WriteLine($"{personName} has been greeted");
}

void SayHelloTo(string personName)
{
    Console.WriteLine($"Hello {personName} from Actual Method");
}
 
delegate void SayHelloTo(string personName);

delegate int DoMath(int numberOne, int numberTwo);