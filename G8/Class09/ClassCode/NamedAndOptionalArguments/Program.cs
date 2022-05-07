#region Methods
void CheckOperation(int num1, int num2, string operation)
{
    switch (operation)
    {
        case "+":
            Console.WriteLine($"{num1} {operation} {num2} = {num1 + num2}");
            break;
        case "-":
            Console.WriteLine($"{num1} {operation} {num2} = {num1 - num2}");
            break ;
        default:
            Console.WriteLine($"The app does not work with {operation}!");
            break;
    }
}

void NoOptional(int num1, int num2, string operation)
{
    CheckOperation(num1, num2, operation);
    //CheckOperation(num2, num1, operation);
}
void SomeOptional(int num1, int num2, string operation = "+")
{
    CheckOperation(num1, num2, operation);
}
void AllOptional(int num1 = 5, int num2 = 10, string operation = "+")
{
    CheckOperation(num1, num2, operation);
}
#endregion


NoOptional(2, 5, "+");
//NoOptional(2, 3); // Will not work since the last is not optional

SomeOptional(2, 5);
SomeOptional(5, 2, "-");

AllOptional();
AllOptional(1);
AllOptional(3, 4);
AllOptional(7, 2, "-");
// AllOptional("-"); // Will not work
AllOptional(operation: "-");
AllOptional(num1: 9, operation: "-");
AllOptional(num1: 17, num2: 9, operation: "-"); // Will works, but has no point
AllOptional(10, operation: "-", num2: 6);
