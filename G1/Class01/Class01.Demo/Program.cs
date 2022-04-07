// See https://aka.ms/new-console-template for more information
using Class01.Demo.Entities;

//Console.WriteLine("Hello, World!");
Manager manager = new Manager("john", "Doe", "Finance", new List<string>() { "Ben A", "Jammy C", "Sean P" });
//Employee employee = new Employee("Jesica", "Bell", "Accounting", 40);

//Console.WriteLine(manager.GetFullname());
//Console.WriteLine(manager.GetInfo("Risto"));
//manager.GetSubordinates();
//Console.WriteLine(employee.GetInfo("Risto"));
//Console.WriteLine(employee.getWorkingHours() + " hours per week!");

int i = 5;
object o = i;

Console.WriteLine(o);
int j = (int)o;
Console.WriteLine(j);

List<object> objects = new List<object>();

for (int i1 = 0; i1 < 5; i1++)
{
    objects.Add(i1);
}

for (int i2 = 0; i2 < 5; i2++)
{
    objects.Add("string" + i2);
}

objects.Add(manager);

Console.WriteLine(objects.Count + " elementi vo listata na objekti");

int counter = 0;
List<int> broevi = new List<int>();
List<string> textovi = new List<string>();
foreach (object o1 in objects)
{
    if (counter < 5)
    {
        broevi.Add((int)o1);
    }
    else if (counter < 10)
    {
        textovi.Add((string)o1);
    }
    else
    {
        Console.WriteLine(((Manager)o1).GetInfo("Riki"));
    }
    counter++;
}

Console.WriteLine(broevi.Sum());

Console.WriteLine("=====================================");
foreach (string s in textovi)
{
    Console.WriteLine(s);
}