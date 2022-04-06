using System.Linq;


string input;

Dictionary<string, int> dictionary = new Dictionary<string, int>();

while(true)
{
    Console.WriteLine("Enter name or press x to exit");
    input = Console.ReadLine().ToLower();

    if (input.ToLower() == "x")
    {
        break;
    }

    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Invalid input");
        continue;
    }

    if (!dictionary.ContainsKey(input))
    {
        dictionary.Add(input, 0);
    }

}

Console.WriteLine("Enter text");
string text = Console.ReadLine();

if (string.IsNullOrEmpty(text))
{
    Console.WriteLine("Invalid text");
    return;
}

// Miki igra fudbal, jovica programira, dragan tepa vreme

string[] words = text.Split(' ');

foreach (string word in words)
{
    if (dictionary.ContainsKey(word))
    {
        dictionary[word] += 1;
    }
}

foreach (KeyValuePair<string, int> keyValue in dictionary)
{
    Console.WriteLine($"{keyValue.Key} - {keyValue.Value}");
}
