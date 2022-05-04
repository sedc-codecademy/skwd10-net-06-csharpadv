// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string currentDirectory = Directory.GetCurrentDirectory();
string folderName = $@"{currentDirectory}\MyNewDirectory";

if (!Directory.Exists(folderName))
{
    Directory.CreateDirectory(folderName);
}

string fileName = $@"{folderName}\users.txt";

//using StreamWriter sw = new StreamWriter(fileName, true);

//sw.WriteLine("Zdravo na site");
//sw.WriteLine("Zdravo na site ushte ednash");
//sw.WriteLine("Zdravo na site ushte 2");
//sw.Flush();
//sw.Close();

using StreamReader sr = new StreamReader(fileName);

while (!sr.EndOfStream)
{
     string line = sr.ReadLine();
    if (line == "Zdravo na site ushte 2")
    {
        Console.WriteLine("Zdravo zdravo");
    }
    else
    {
        Console.WriteLine(line);
    }

    if (line == "prekini")
    {
        break;
    }
}