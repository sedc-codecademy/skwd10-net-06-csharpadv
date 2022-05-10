using NullableTypes.Domain;

Person firstPerson = new Person();
Console.WriteLine(firstPerson.Id); // by default is zero
Console.WriteLine(firstPerson.Score); // null by default

firstPerson.Id = 5;
//firstPerson.Id = null; //ERROR
firstPerson.Score = 3;
Console.WriteLine(firstPerson.Score);
firstPerson.Score = null;
Console.WriteLine(firstPerson.Score);

Console.WriteLine(firstPerson.Address == null);
firstPerson.Address = "Partizanska";
Console.WriteLine(firstPerson.Address == null);
Console.WriteLine(firstPerson.Address);
firstPerson.Address = null;
Console.WriteLine(firstPerson.Address);

Console.ReadLine(); 