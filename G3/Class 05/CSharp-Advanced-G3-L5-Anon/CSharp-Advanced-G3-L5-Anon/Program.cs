// See https://aka.ms/new-console-template for more information

Func<string, bool> isValidNumber = text => int.TryParse(text, out int parsed); 

Func<int> getRandomNumber = () =>
{
    Random random = new Random();
    return random.Next(1, 100);
};

Func<int, int, int> addTwoNumbers = (firstNumber, secondNumber) =>
{
    return firstNumber + secondNumber;
};

int randomNumber = getRandomNumber();
Console.WriteLine(randomNumber);

Console.WriteLine("Enter two numbers:");

int first;
int second;

string firstString = Console.ReadLine();
if (isValidNumber(firstString))
{
    first = int.Parse(firstString);
}
else
{
    Console.WriteLine("The first number was not valid");
    return;
}

string secondString = Console.ReadLine();
if (isValidNumber(secondString))
{
    second = int.Parse(secondString);
}
else
{
    Console.WriteLine("The second number was not valid");
    return;
}

Console.WriteLine($"The additon of the two numbers is {addTwoNumbers(first, second)}");



