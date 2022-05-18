// See https://aka.ms/new-console-template for more information
using MakingAttributes;
using System.Reflection;

Console.WriteLine("Hello, World!");


//Console.WriteLine(Person.ClassDescription);
// ProprertyDescriptionAttribute pda = new ProprertyDescriptionAttribute("asdasdas");

//var personType = typeof(Person);

//var cda = personType.GetCustomAttribute<ClassDescriptionAttribute>();
//Console.WriteLine($"{nameof(Person)} - {cda.Description}");

//foreach (var pinfo in personType.GetProperties())
//{
//    var pda = pinfo.GetCustomAttribute<ProprertyDescriptionAttribute>();
//    if (pda != null)
//    {
//        Console.WriteLine($"  {pinfo.Name} - {pda.Description}");
//    } else
//    {
//        Console.WriteLine($"  {pinfo.Name} - No Description");
//    }
//}


//var personType = typeof(Person);

Console.WriteLine("-----------------");

var assembly = Assembly.GetExecutingAssembly();
foreach(var type in assembly.GetTypes())
{
    Console.WriteLine($"Found type {type.Name}");
    var cda = type.GetCustomAttribute<ClassDescriptionAttribute>();
    if (cda == null)
    {
        Console.WriteLine($"{type.Name} - No Description");
    }
    else
    {
        Console.WriteLine($"{type.Name} - {cda.Description}");
    }

    foreach (var pinfo in type.GetProperties())
    {
        var pda = pinfo.GetCustomAttribute<ProprertyDescriptionAttribute>();
        if (pda != null)
        {
            Console.WriteLine($"  {pinfo.Name} - {pda.Description}");
        }
        else
        {
            Console.WriteLine($"  {pinfo.Name} - No Description");
        }
    }
    Console.WriteLine("-----------------");
}

