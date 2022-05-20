// See https://aka.ms/new-console-template for more information
using Attributing;

using System.Reflection;

var weko = new Person
{
    FirstName = "Wekoslav",
    LastName = "Stefanovski",
    ID = 1
};

//var aneta = new Person();

var thePersonType = weko.GetType();

//Console.WriteLine(weko == aneta); // false
//Console.WriteLine(thePersonType == aneta.GetType()); // true

var methods = thePersonType.GetMethods(BindingFlags.Public | BindingFlags.Static);
Console.WriteLine(methods.Length);
foreach (var mi in methods)
{
    Console.WriteLine("--------------");
    Console.WriteLine(mi.Name);
    Console.WriteLine(mi.ReturnType.Name);
    foreach (var pi in mi.GetParameters())
    {
        Console.WriteLine($"  {pi.Name} - {pi.ParameterType.Name}");
    }
}

var ctors = thePersonType.GetConstructors();
foreach (var ci in ctors)
{
    Console.WriteLine($"Constructor {ci.Name}");
    foreach (var pi in ci.GetParameters())
    {
        Console.WriteLine($"  {pi.Name} - {pi.ParameterType.Name}");
    }
}

var getFullNameMethod = thePersonType.GetMethod("GetFullName");


// weko.GetFullName("Mr.");
var wekoFullName = getFullNameMethod.Invoke(weko, new object[] { "Mr." });
Console.WriteLine(wekoFullName);


var aneta = Activator.CreateInstance(thePersonType);

var firstNameProp = thePersonType.GetProperty("FirstName");
firstNameProp.GetSetMethod().Invoke(aneta, new object[] { "Aneta" });

var lastNameProp = thePersonType.GetProperty("LastName");
lastNameProp.SetValue(aneta, "Stankovska");

var anetaFullName = getFullNameMethod.Invoke(aneta, new object[] {null});
Console.WriteLine(anetaFullName);

