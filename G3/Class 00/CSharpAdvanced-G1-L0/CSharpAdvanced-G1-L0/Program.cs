// See https://aka.ms/new-console-template for more information

List<string> names = new List<string>();

do
{
    Console.WriteLine("Enter name:");
    string name = Console.ReadLine();

    if (name.ToLower() == "x")
    {
        break;
    }
    else
    {
        names.Add(name);
    }
} while (true);

Console.WriteLine("Please enter text");
string enteredText = Console.ReadLine();

string[] enteredWords = enteredText.Split(' ');

foreach (string name in names)
{
    int wordCount = 0;
    foreach (string word in enteredWords)
    {
        if (word.ToLower() == name.ToLower())
        {
            wordCount++;
        }
    }

    Console.WriteLine($"The word {name} is contained {wordCount} times");

    
}
