using Class11.Demo1.Entities;
using Class11.Demo1.Services;
using Newtonsoft.Json;

Console.WriteLine("=============== Serialization/Deserialization ===============");

#region File system data
string appDir = @"..\..\..\Data";
string filePath = appDir + @"\JsonData.json";
OurJsonSerializer serializer = new OurJsonSerializer();
CustomReaderWriter customReaderWriter = new CustomReaderWriter();

if (!Directory.Exists(appDir))
{
    Directory.CreateDirectory(appDir);
}

#endregion

#region Manual serialization/deserialization
Student student = new Student();
student.Id = 1;
student.FirstName = "John";
student.LastName = "Doe";
student.Age = 25;
student.IsPartTime = false;

string json = serializer.SerializeStudent(student);
Console.WriteLine(json);
customReaderWriter.WriteFile(filePath, json);
Console.ReadLine();

string jsonFromFile = customReaderWriter.ReadFile(filePath);
Student deserializedStudent = serializer.DeserializeStudent(jsonFromFile);

Console.WriteLine($"Student: {deserializedStudent.Id}) {deserializedStudent.FirstName} {deserializedStudent.LastName} age: {deserializedStudent.Age} part time:{deserializedStudent.IsPartTime}");

#endregion

#region Newtonsoft JSON serialization/deserialization

string serializedJson = JsonConvert.SerializeObject(student);

Console.WriteLine(serializedJson);

Student deserializedWithNewtonsoft = JsonConvert.DeserializeObject<Student>(serializedJson);
Console.WriteLine($"Student: {deserializedWithNewtonsoft.Id}) {deserializedWithNewtonsoft.FirstName} {deserializedWithNewtonsoft.LastName} age: {deserializedWithNewtonsoft.Age} part time:{deserializedWithNewtonsoft.IsPartTime}");

#endregion