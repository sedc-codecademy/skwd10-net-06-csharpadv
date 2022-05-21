int Calculate(char operation, int num01, int num02)
{
    // local functions
    int LocalAdd(int a, int b) { return a + b; }
    int LocalSubstract(int a, int b) { return a - b; }

    //LocalAdd(num02, 23);
    //LocalSubstract(9, num01);

    int result = operation switch
    {
        '+' => LocalAdd(num01, num02),
        '-' => LocalSubstract(num01, num02),
        _ => throw new ArgumentException("Not valid operation")
    };
    return result;
}

// Adding local function in Main
void SayHello(string name) { Console.WriteLine($"Hello {name}"); }

SayHello("Angel");
// lines
SayHello("Petre");

// Working with method that has local functions
Console.WriteLine($"7 + 8 = {Calculate('+', 7, 8)}");
Console.WriteLine($"7 - 8 = {Calculate('-', 7, 8)}");
Console.ReadLine();
