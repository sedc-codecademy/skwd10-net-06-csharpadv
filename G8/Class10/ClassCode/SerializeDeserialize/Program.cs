using Newtonsoft.Json;
using SerializeDeserialize.Domain;
using SerializeDeserialize.Helpers;
using SerializeDeserialize.Services;

string Path = @"..\..\..\Data";
string FilePath = Path + "\\data.json";

//MANUAL

if (!Directory.Exists(Path))
{
    Directory.CreateDirectory(Path);
}
Student student = new Student()
{
    FirstName = "Bob",
    LastName = "Bobsky",
    Age = 22,
    IsPartTime = false
};

//FileSystemService fileSystemService = new FileSystemService();
//OurJsonSerializer ourJsonSerializer = new OurJsonSerializer();
//string jsonResult = ourJsonSerializer.SerializeStudent(student);
//Console.WriteLine(jsonResult);

////write to json file
//fileSystemService.WriteInFile(FilePath, jsonResult);

////read from json file
//string jsonStudent = fileSystemService.ReadFileContent(FilePath);
//Student ourStudent = ourJsonSerializer.DeserializeStudent(jsonStudent);
//Console.WriteLine(ourStudent.FirstName);

//LIBRARY -> NEWTONSOFT.JSON

string jsonString = JsonConvert.SerializeObject(student);
Console.WriteLine(jsonString);

Student deserializedStudent = JsonConvert.DeserializeObject<Student>(jsonString);
Console.WriteLine(deserializedStudent.FirstName);

Console.ReadLine();

