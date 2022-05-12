using Class10.Demo1.Entities;
using Class10.Demo1.Helpers;

Console.WriteLine("=============== Disposable ===============");

#region Preparation data
string AppPath = @"..\..\..\Text";
string FilePath = AppPath + @"\text.txt";

void CreateFolder(string path)
{
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
}

void CreateFile(string path)
{
    if (!File.Exists(path))
    {
        File.Create(path).Close();
    }
}

//Pinter 

static void TestMethod()
{
    TestEntity test = new TestEntity() { value = 3 };
    test.value = 4;
    TestEntity test2 = test;
    test2.value = 5;

    Console.WriteLine(test.value);
}
#endregion

#region Manual Disposal
//stream writer dispose method
static void AppendStringToFile(string text, string filePath)
{
    StreamWriter streamWriter = new StreamWriter(filePath, true);
    streamWriter.WriteLine(text);
    streamWriter.Dispose();
}

//stream reader dispose method
static void ReadFromFile(string filePath)
{
    StreamReader reader = new StreamReader(filePath);
    string text = reader.ReadToEnd();
    Console.WriteLine(text);
    reader.Dispose();
}

//method call code
#endregion

#region Disposal with Using
//stream writer dispose method
static void AppendStringToFileSafe(string text, string filePath)
{
    using (StreamWriter streamWriter = new StreamWriter(filePath, true))
    {
        streamWriter.WriteLine(text);
        Console.WriteLine("Text added to file form Safe class!");
    }
}

//stream reader dispose method
static void ReadFromFileSafe(string filePath)
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string text = reader.ReadToEnd();
        Console.WriteLine(text);
    }
}

//method call code
#endregion

#region Dispose with our own class
//stream writer dispose method
void AppendTextInFileCustomImpl(string text, string filePath)
{
    using (OurWriter ow = new OurWriter(filePath))
    {
        ow.Write(text);
    }
}

//stream reader dispose method
static void ReadFromFileSafeCustomImpl(string filePath)
{
    using (OurReader reader = new OurReader(filePath))
    {
        string text = reader.Read();
        Console.WriteLine(text);
    }
}


//method call code
#endregion


#region Main
//create folder
if (!Directory.Exists(AppPath))
{
    CreateFolder(AppPath);
}
//create file
if (!File.Exists(FilePath))
{
    CreateFile(FilePath);
}

//Console.WriteLine("============= WRITE TO FILE ============");
//AppendStringToFile("Add some text to the file!", FilePath);
//Console.WriteLine("============= READ FROM FILE ============");
//ReadFromFile(FilePath);

//Console.WriteLine("============= WRITE TO FILE ============");
//AppendStringToFileSafe("Add some text to the file!", FilePath);
//Console.WriteLine("============= READ FROM FILE ============");
//ReadFromFileSafe(FilePath);

Console.WriteLine("============= WRITE TO FILE ============");
AppendTextInFileCustomImpl("Add some text to the file from our custom class!", FilePath);
Console.WriteLine("============= READ FROM FILE ============");
ReadFromFileSafeCustomImpl(FilePath);
#endregion