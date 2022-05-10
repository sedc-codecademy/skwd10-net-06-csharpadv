using Class10.Demo2;

Console.WriteLine("=================== Nullable ======================");
Person person = new Person();
Console.WriteLine(person.Id);
Console.WriteLine(person.Points == null ? "null" : person.Points);
Console.WriteLine(person.HasPet);
Console.WriteLine(person.HasDrivingLicense);

Console.WriteLine(person.Name == null);
person.Name = "Riki";
Console.WriteLine(person.Name);
person.Name = null;
Console.WriteLine(person.Name == null);

