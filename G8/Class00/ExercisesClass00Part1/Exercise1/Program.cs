// See https://aka.ms/new-console-template for more information

List<string> names = new List<string>();
string userInput = string.Empty;
do
{
    Console.WriteLine("Please enter a name");
    string name = Console.ReadLine();
    if (IsNameValid(name))
    {
        names.Add(name);
    }
    else
    {
        throw new Exception("The name you entered is not valid");
    }
    Console.WriteLine("Plese enter any key except x to add an other name");
    userInput = Console.ReadLine();
} while (userInput != "x" && userInput != "X");
Console.WriteLine("Please enter a name to search for");
string firstName = Console.ReadLine();
Console.WriteLine("Please enter a text");
string text = Console.ReadLine();
int numberOfOccurences = GetNumberOfNameOccurencesInText(firstName, text, names);
Console.WriteLine($"The number of times the name appears in the text is {numberOfOccurences}");
Console.ReadLine();

//Method signature is the return method type, the method name and the parameter type
//static void PrintMyName(string myName)
//{
//    Console.WriteLine($"My name is {myName}");
//}

static bool IsNameValid(string name)
{
    bool isDigit = false;
    bool isWhiteSpace = false;
    if (name.Length < 3)
        return false;

    foreach (char character in name)
    {
        if (Char.IsDigit(character))
        {
            isDigit = true;
            Console.WriteLine("");
        }
        if (Char.IsWhiteSpace(character))
        {
            isWhiteSpace = true;
        }
    }
    return !isDigit && !isWhiteSpace;
}

static int GetNumberOfNameOccurencesInText(string name, string text, List<string> names)
{
    bool isNameEqualToFirstName = false;
    foreach (string firstName in names)
    {
        if (firstName == name)
        {
            isNameEqualToFirstName = true;
        }
    }
    if (!isNameEqualToFirstName)
    {
        throw new Exception("The name you provided is not contained in the list of names");
    }

    string[] textWords = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int result = 0;
    foreach (string fName in textWords)
    {
        if (fName.ToLower() == name.ToLower())
        {
            result++;
        }
    }
    return result;
}