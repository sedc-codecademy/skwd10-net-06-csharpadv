// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

using System.Xml.Serialization;

using WritingObjects;

Console.WriteLine("Hello, World!");

XmlSerializer x = new XmlSerializer(typeof(Person));

var weko = new Person
{
    Id = Guid.NewGuid(),
    FirstName = "Wekoslav",
    LastName = "Stefanovski",
    Age = 0x2c
};


Console.WriteLine(int.MaxValue);
Console.WriteLine(int.MinValue);
Console.WriteLine(long.MaxValue);
Console.WriteLine(long.MinValue);
x.Serialize(Console.Out, weko);
Console.WriteLine();

//var wekoStr = "<?xml version=\"1.0\" ?><Person xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><FirstName>Wekoslav</FirstName><LastName>Stefanovski</LastName><Age>44</Age></Person>";

//var weko2 = x.Deserialize(Utils.GenerateStreamFromString(wekoStr));
//Console.WriteLine(weko2);
//Console.WriteLine(weko2.GetType().FullName);

var wekoJson = JsonConvert.SerializeObject(weko);
Console.WriteLine(wekoJson);

var weko3 = JsonConvert.DeserializeObject<Person>(wekoJson);

Console.WriteLine(weko3.FirstName);
