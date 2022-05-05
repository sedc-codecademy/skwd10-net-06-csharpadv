string appPath = @"..\..\..\";
string folderPath = appPath + @"myFolder\";
string filePath = folderPath + @"test.txt";

if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
    Console.WriteLine("New directory was created!");
}

#region FileManipulation - Stream

// Writinf with StreamWriter
using (StreamWriter sw = new StreamWriter(filePath))
{
    sw.WriteLine("Hello SEDC!");
    sw.WriteLine("We are writing text from StreamWriter");
    Console.WriteLine("Writing is complete");
}
Console.ReadLine();

// Writing without rewriting the document with StreamWriter
using (StreamWriter sw = new StreamWriter(filePath))
{
    sw.WriteLine("Hello AGAIN!");
    sw.WriteLine("This is written on the top of the previous one!");
    Console.WriteLine("Writing again");
}
Console.ReadLine();

using(StreamReader sr = new StreamReader(filePath))
{
    string firstLine = sr.ReadLine();
    //string secondLine = sr.ReadLine();
    string restContent = sr.ReadToEnd();

    Console.WriteLine($"First Line:{firstLine}");
    //Console.WriteLine($"Second Line:{secondLine}");
    Console.WriteLine($"Rest of content: {restContent}");
}

#endregion
