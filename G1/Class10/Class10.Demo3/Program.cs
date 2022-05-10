Console.WriteLine("============== Working with parameters ==============");
void ExecuteOperation(int num1, int num2, string operation)
{
    switch (operation)
    {
        case "+":
            Console.WriteLine($"{num1} {operation} {num2} = {num1 + num2}");
            break;
        case "-":
            Console.WriteLine($"{num1} {operation} {num2} = {num1 - num2}");
            break;
        default:
            Console.WriteLine("Operation not implemented yet!");
            break;
    }
}

void SumWhenNoOperationSent(int num1, int num2, string operation = "+")
{
    ExecuteOperation(num1, num2, operation);
}

void SumWhenNoOperationAndNum2Sent(int num1, int num2 = 5, string operation = "+")
{
    ExecuteOperation(num1, num2, operation);
}

void AllOptional(int num1 = 1, int num2 = 5, string operation = "+")
{
    ExecuteOperation(num1, num2, operation);
}

ExecuteOperation(2, 3, "-");
ExecuteOperation(num2: 4, operation: "+", num1: 3);

SumWhenNoOperationSent(2, 3, "-");

SumWhenNoOperationAndNum2Sent(7);
SumWhenNoOperationAndNum2Sent(7, 4);

AllOptional(operation: "-");