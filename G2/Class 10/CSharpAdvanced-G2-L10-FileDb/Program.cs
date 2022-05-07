// See https://aka.ms/new-console-template for more information
using CSharpAdvanced_G2_L10_FileDb.Database;
using CSharpAdvanced_G2_L10_FileDb.Entities;

PersonDatabase personDb = new PersonDatabase();

//Person person = new Person("Mihajlo", "Dimovski", 25, new Car(1, "KIA", "Ceed"));
//Person person2 = new Person("Mihajlo", "Dimovski", 25, new Car(1, "KIA", "Ceed"));
//Person person3 = new Person("Mihajlo", "Dimovski", 25, new Car(1, "KIA", "Ceed"));
//Person person4 = new Person("Mihajlo", "Dimovski", 25, new Car(1, "KIA", "Ceed"));

//personDb.Insert(person);
//personDb.Insert(person2);
//personDb.Insert(person3);
//personDb.Insert(person4);

while (true)
{
    Console.WriteLine("Current people in database");
    Console.WriteLine("--------------------------------");
    personDb.GetAll().ForEach(Console.WriteLine);
    Console.WriteLine("--------------------------------");

    Console.WriteLine("Enter person first name");
    string firstName = Console.ReadLine();

    Console.WriteLine("Enter person last name");
    string lastName = Console.ReadLine();

    Console.WriteLine("Enter person age");
    string ageNonParsed = Console.ReadLine();
    int age = int.Parse(ageNonParsed);

    Person person = new Person(firstName, lastName, age, new Car(1, "KIA", "Ceed"));
    personDb.Insert(person);
}
