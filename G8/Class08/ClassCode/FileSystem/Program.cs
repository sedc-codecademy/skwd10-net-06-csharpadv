#region DirectoryManipulation
// Check what folder is your apllication
string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine(currentDirectory);

// Relative path to our application folder
string appPath = @"..\..\..\";
// Absolute path to our application folder
//string appPath = @"C:\Users\User\Desktop\Class08\ClassCode\FileSystem\";

// Chech if a folder exist
bool myFolderExists = Directory.Exists(appPath + @"myFolder");
bool myFolderExistsString = Directory.Exists(@"C:\Users\User\Desktop\Class08\ClassCode\FileSystem\myFolder");
bool myFolder2Exist = Directory.Exists(appPath + @"myFolder2");
Console.WriteLine($"Does myFolder exists: {myFolderExists}");
Console.WriteLine($"Does myFolderExistsString exists: {myFolderExistsString}");
Console.WriteLine($"Does myFolder2Exist exists: {myFolder2Exist}");

//Create a new folder
string newFolder = appPath + @"newFolder";
Console.WriteLine($"Does newFolder  exists before: {Directory.Exists(newFolder)}");
if (!Directory.Exists(newFolder))
{
    Directory.CreateDirectory(newFolder);
    Console.WriteLine("New directory was created!");
}
Console.WriteLine($"Does newFolder  exists after: {Directory.Exists(newFolder)}");


Console.WriteLine("Press anything to delete newFolder...");
Console.ReadLine();

// Delete a directory
if (Directory.Exists(newFolder))
{
    Directory.Delete(newFolder);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("newFolder was DELETED!");
    Console.ResetColor();
}
Console.ReadLine();
#endregion

#region FileManipulation - File
string filePath = appPath + @"myFolder\";
if (!Directory.Exists(filePath))
{
    Directory.CreateDirectory(filePath);
    Console.WriteLine("New directory was created!");
}

// File exists
bool testTxtExists = File.Exists(filePath + @"test.txt");
bool test2TxtExists = File.Exists(filePath + @"test2.txt");
Console.WriteLine($"Does test.txt exists: {testTxtExists}");
Console.WriteLine($"Does test2.txt exists: {test2TxtExists}");

// File Create
if(!File.Exists(filePath + @"test.txt"))
{
    File.Create(filePath + @"test.txt").Close();
    Console.WriteLine("A file was created!");
}

//Console.WriteLine("To delete this file pess anything...");
//Console.ReadLine();

//if (File.Exists(filePath + @"test.txt"))
//{
//    File.Delete(filePath + @"test.txt");
//    Console.WriteLine("A file was deleted");
//}
//Console.ReadLine();

// Write in a file
string testTxtPath = filePath + @"test.txt";
if (File.Exists(testTxtPath))
{
    File.WriteAllText(testTxtPath, "Hello SEDC! We are writing in a file");
    Console.WriteLine("Successfully written in a file!");
}
Console.ReadLine();

if (File.Exists(testTxtPath))
{
    File.WriteAllText(testTxtPath, "Hello SEDC! We are writing in a file again");
    Console.WriteLine("Successfully written in a file!");
}

// Read from a file
if (File.Exists(testTxtPath))
{
    string content = File.ReadAllText(testTxtPath);
    Console.WriteLine("This is the text:");
    Console.WriteLine(content);
}
Console.ReadLine();
#endregion
