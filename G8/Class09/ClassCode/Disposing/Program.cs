using Disposing.InputOutputHelper;

string AppPath = @"..\..\..\Text";
string FilePath = AppPath + @"\text.txt";

void CreateFolder()
{
    if (!Directory.Exists(AppPath))
    {
        Directory.CreateDirectory(AppPath);
    }
}

void CreateFile()
{
    if (!File.Exists(FilePath))
    {
        File.Create(FilePath).Close();
    }
}

void AppendTextInFile(string text)
{
    OurWriter ourWriter = new OurWriter(FilePath);
    ourWriter.Write(text);
    ourWriter.Dispose();
}

string ReadFromFile()
{
    OurReader ourReader = new OurReader(FilePath);
    string text = ourReader.Read();
    ourReader.Dispose();
    return text;
}

CreateFolder();
CreateFile();
//MANUAL DISPOSE(.dISPOSE())
AppendTextInFile("Hello from group G8");
AppendTextInFile("Hello Sedc");
AppendTextInFile("We are already done with C#");

Console.WriteLine(ReadFromFile());

//DISPOSE WITH USING, calls Dispose in the background
using(OurReader reader = new OurReader(FilePath))
{
    Console.WriteLine(reader.Read());
}
Console.ReadLine();