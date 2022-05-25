try
{
    //Console.WriteLine("You have the numbers 2 and 9. Enter the operation for calculating: (+, -, *, /)");
    PrintMessage(MessageType.Info, "You have the numbers 2 and 9. Enter the operation for calculating: (+, -, *, /)");
    string operation = Console.ReadLine();
    //int result;

    //// old switch statement
    //switch (operation)
    //{
    //    case "+":
    //        result = 2 + 9;
    //        break;
    //     case "-":
    //        result = 2 - 9;
    //        break;
    //    case "*":
    //        result = 2 * 9;
    //        break ;
    //     case "/":
    //        result = 2 / 9;
    //        break;
    //    default:
    //        throw new ArgumentException("Invalid input");
    //        break;

    //}

    // new switch expression
    int result = operation switch
    {
        "+" => 2 + 9,
        "-" => 2 - 9,
        "*" => 2 * 9,
        "/" => 2 / 9,
        _ => throw new ArgumentException("Invalid input")
    };

    //Console.WriteLine(result);
    PrintMessage(MessageType.Success, $"The result is {result}");
}
catch (Exception ex)
{
    PrintMessage(MessageType.Error, ex.Message);
}

void PrintMessage(MessageType type, string message)
{
    ConsoleColor consoleColor = type switch
    {
        MessageType.Warning => ConsoleColor.Yellow,
        MessageType.Error => ConsoleColor.Red,
        MessageType.Info => ConsoleColor.Blue,
        MessageType.Success => ConsoleColor.Green,
        _=> throw new ArgumentException("No such message type")
    };
    Console.ForegroundColor = consoleColor;
    Console.WriteLine(message);
    Console.ResetColor();
}

public enum MessageType
{
    Warning,
    Error,
    Info,
    Success
}
