#region Directory manipulation
//check current application folder
Console.WriteLine("Working with File System");
string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine(currentDirectory);

string absolutePath = @"C:\Projects\SEDC\skwd10-net-06-csharpadv\G1\Class09\Class09.Demo1";
string relativePath = "../../../";
string relativeFolderPath = "../../../DemoFolder/";
Console.ReadLine();
Console.WriteLine("=========================== FOLDER ==============================");
Console.WriteLine("Check If Folder Exists");
Console.WriteLine();
//check if directory exists
bool exists = Directory.Exists(relativePath + "/DemoFolder1");
if (exists)
{
    Console.WriteLine("DemoFolder directory exists.");
}
else
{
    Console.WriteLine("DemoFolder directory does not exists.");
}


//create new directory
Console.WriteLine("=========================================================");
Console.WriteLine("Create Folder");
Console.WriteLine();
string newFolderPath = relativePath + "/DemoFolder002";

if (Directory.Exists(newFolderPath))
{
    Console.WriteLine("Folder already exists");
}
else
{
    Directory.CreateDirectory(newFolderPath);
    Console.WriteLine("Folder Created.");
}


//delete directory
Console.WriteLine("=========================================================");
Console.WriteLine("Delete folder");
Console.WriteLine();
string folderForDelete = relativePath + "/DemoFolder002";

if (Directory.Exists(folderForDelete))
{
    Directory.Delete(folderForDelete, true); //true is used for deleting not empry folders (recoursive delete sub-folders and files)
}
else
{
    Console.WriteLine("Folder does not exists");
}
#endregion

#region File manipulation
//check if directory exists if not create it
if (!Directory.Exists(relativeFolderPath))
{
    Directory.CreateDirectory(relativeFolderPath);
}

//check if file exists
Console.WriteLine("========================= FILE ================================");
Console.WriteLine("Check If File Exists");
Console.WriteLine();
string filename = "test.txt";

if (File.Exists(relativeFolderPath + filename))
{
    Console.WriteLine("File already exists");
}
else
{
    Console.WriteLine("File does not exists");
}

//create file

Console.WriteLine("=========================================================");
Console.WriteLine("Create File");
Console.WriteLine();
if (!File.Exists(relativeFolderPath + filename))
{
    File.Create(relativeFolderPath + filename).Close();
}

if (File.Exists(relativeFolderPath + filename))
{
    Console.WriteLine("File already exists");
}
else
{
    Console.WriteLine("File does not exists");
}

//delete a file
Console.WriteLine("=========================================================");
Console.WriteLine("Delete File");
Console.WriteLine();
if (File.Exists(relativeFolderPath + filename))
{
    File.Delete(relativeFolderPath + filename);
}


if (File.Exists(relativeFolderPath + filename))
{
    Console.WriteLine("File already exists");
}
else
{
    Console.WriteLine("File does not exists");
}

//write in file
Console.WriteLine("=========================================================");
Console.WriteLine("Check if file exists, if exists write data in it, if not exist create it and write data in it.");
Console.WriteLine();
if (File.Exists(relativeFolderPath + filename))
{
    File.WriteAllText(relativeFolderPath + filename, "Some dummy text to be added in the file.");
}
else
{
    File.Create(relativeFolderPath + filename).Close();
    File.WriteAllText(relativeFolderPath + filename, "Some dummy text to be added in the file.");
    Console.WriteLine("File created (deleted in previous delete example), and data writen in it.");
}

//read from file
Console.WriteLine("=========================================================");
Console.WriteLine("Read all data from file");
Console.WriteLine();
if (File.Exists(relativeFolderPath + filename))
{
    string text = File.ReadAllText(relativeFolderPath + filename);
    Console.WriteLine(text);
}

#endregion
