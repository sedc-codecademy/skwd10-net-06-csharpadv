// See https://aka.ms/new-console-template for more information
using BuildingStrings;

using System.Diagnostics;
using System.Text;

Console.WriteLine("Hello, World!");


var pf = new PersonFactory();

var persons = pf.GetPersons().ToList();
Console.WriteLine(persons.Count());

string bigResult = string.Empty;
Stopwatch sw = Stopwatch.StartNew();
foreach (var person in persons)
{
    bigResult += person.ToString() + Environment.NewLine;
}
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);
Console.WriteLine(bigResult.Length);
// Console.WriteLine(bigResult);

Stopwatch sw2 = Stopwatch.StartNew();
var bigResult2 = new StringBuilder();
foreach (var person in persons)
{
    bigResult2.AppendLine(person.ToString());
}
sw2.Stop();
Console.WriteLine(sw2.ElapsedMilliseconds);
Console.WriteLine(bigResult2.Length);