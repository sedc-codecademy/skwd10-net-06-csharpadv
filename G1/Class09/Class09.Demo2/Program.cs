#region Initial data
Console.WriteLine("Working with File streams");
//prepare paths for folder and file
string filePath = "../../../DemoFolder/test.txt";
#endregion

#region File manipulation
//writing with StreamWriter
Console.WriteLine("=========================================================");
StreamWriter sw = new StreamWriter(filePath);
sw.WriteLine("First line added using stream writer");
sw.WriteLine("Second line added using stream writer");
sw.WriteLine("Third line added using stream writer");
sw.Close();

Console.WriteLine("Writing to file finished 1");

Console.ReadLine();

// Writing without rewriting the document with StreamWriter (if we don't have true in StreamWriter(filePath, true) the
// previous writen data will be overwritn and only the data below will be writen in test.txt file)
Console.WriteLine("=========================================================");
using (sw = new StreamWriter(filePath, true))
{
    sw.WriteLine("Fourth line added using stream writer");
    sw.WriteLine("Fifth line added using stream writer");
    sw.WriteLine("Sixth line added using stream writer");
    Console.WriteLine("Writing to file finished 2");
}

// Reading with StreamReader
Console.WriteLine("=========================================================");
StreamReader sr = new StreamReader(filePath);

string first = sr.ReadLine();
string second = sr.ReadLine();
string rest = sr.ReadToEnd();
sr.Close();

Console.WriteLine(first);
Console.WriteLine("=========================================================");
Console.WriteLine(second);
Console.WriteLine("=========================================================");
Console.WriteLine(rest);
Console.WriteLine("=========================================================");

//reading all text with while
Console.WriteLine("=========================================================");
using (sr = new StreamReader(filePath))
{
    string currentLine = string.Empty;
    while (!sr.EndOfStream)//(currentLine = sr.ReadLine()) != null) //another option how to loop through all lines of stream reader
    {
        currentLine = sr.ReadLine();// should be removed if (!sr.EndOfStream) condition is not used, data is read directlly in while loop
        Console.WriteLine(currentLine);
    }
}
#endregion