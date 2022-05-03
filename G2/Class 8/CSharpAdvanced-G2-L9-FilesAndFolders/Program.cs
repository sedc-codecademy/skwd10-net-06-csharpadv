// See https://aka.ms/new-console-template for more information
using System.Text;

//Console.WriteLine(Directory.GetCurrentDirectory());

//Directory.CreateDirectory("HelloWorld");

//if (Directory.Exists("HelloWorld"))
//{
//    Console.WriteLine("Directory sucessfully created");
//}
//else
//{
//    Console.WriteLine("Directory does not exist");
//}


// File.AppendAllLines($"{Directory.GetCurrentDirectory()}/file1.txt", new List<string>() { "Hello From Resen" });
//File.AppendAllText($"{Directory.GetCurrentDirectory()}/file1.txt", "Hello From Skopje");

//using (FileStream fs = File.Create(@"C:\Users\Miki-Laptop\source\repos\CSharpAdvanced-G2-L9-FilesAndFolders\CSharpAdvanced-G2-L9-FilesAndFolders\bin\Debug\net6.0\file2.txt"))
//{
//    fs.Write(Encoding.ASCII.GetBytes("Nikola"));
//    fs.Flush();

//    fs.Seek(0, SeekOrigin.Begin);

//    fs.Close();
//}

string myDirectory = @"..\..\MyDirectory";

if (!Directory.Exists(myDirectory))
{
    Directory.CreateDirectory(myDirectory);
}

string membersFilePath = $@"{myDirectory}\members.txt";

while (true)
{
    if (!File.Exists(membersFilePath))
    {
        using FileStream fs = File.Create(membersFilePath);
        fs.Write(Encoding.ASCII.GetBytes("Nikola;21;Budimpesta"));
        fs.Close();
    }
    else
    {
        string content = File.ReadAllText(membersFilePath);
        Console.WriteLine(content);

        Console.WriteLine("Enter a new member");
        string memberInfo = Console.ReadLine();

        File.AppendAllText(membersFilePath, memberInfo);
    }
}



