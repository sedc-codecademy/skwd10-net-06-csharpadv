using CSharpAdvanced_G2_L10_SerializationDeserialization.Entities;
using Newtonsoft.Json;

// Serialization
List<Student> students = new List<Student>() {
    new Student("Mihajlo", "Dimovski", 25), 
    new Student("Bojan", "Damcevski", 24), 
    new Student("David", "Shumanski", 21)
};


string result = JsonConvert.SerializeObject(students);
string filePath = @$"{Directory.GetCurrentDirectory()}\file.json";
string oneObjectFilePath = @$"{Directory.GetCurrentDirectory()}\oneObject.json";

if (!File.Exists(filePath))
{
    var stream = File.Create(filePath);
    stream.Close();
}

if (!File.Exists(oneObjectFilePath))
{
    var stream = File.Create(filePath);
    stream.Close();
}


using (StreamWriter sw = new StreamWriter(filePath))
{
    sw.Write(result);
    sw.Flush();
}


Student oneObjectStudent = new Student("One", "object", 1111111);
string oneObjectJson = JsonConvert.SerializeObject(oneObjectStudent);

using (StreamWriter sw = new StreamWriter(oneObjectFilePath))
{
    sw.Write(oneObjectJson);
    sw.Flush();
}

Console.WriteLine(oneObjectJson + " ONE OBJECT STUDENT!!!");

Console.WriteLine(result);

// Deserialization
string json;
using (StreamReader sr = new StreamReader(filePath))
{
    json = sr.ReadToEnd();
    Console.WriteLine(json);
}
List<Student> studentsDeserialized = JsonConvert.DeserializeObject<List<Student>>(json);

using (StreamReader sr = new StreamReader(oneObjectFilePath))
{
    json = sr.ReadToEnd();
    Console.WriteLine(json);
}

Student oneObjectDeserialized = JsonConvert.DeserializeObject<Student>(json);

Console.WriteLine("End");