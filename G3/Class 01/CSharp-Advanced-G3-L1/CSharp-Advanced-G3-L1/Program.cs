// See https://aka.ms/new-console-template for more information
using Enteties;

Person employee = new Employee(1, "Trajko", "Trajkov", 40);
Person admin = new Admin(2, "Petko", "Petkov", "HR");

Console.WriteLine(employee.GetInfo());
Console.WriteLine(admin.GetInfo());

Figura krug = new Krug(5);
Figura kvadrat = new Kvadrat(10);

Console.WriteLine(krug.PresmetajPlostina());
Console.WriteLine(kvadrat.PresmetajPlostina());
