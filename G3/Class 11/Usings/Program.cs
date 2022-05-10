// See https://aka.ms/new-console-template for more information
using Usings;

Console.WriteLine("Hello, World!");

using (var fm = new FileManager("File.log"))
{
    fm.WriteLine("Hi First");
    fm.WriteLine("Hi Second");
    fm.WriteLine("Здраво на кирилица");
};


Console.WriteLine("Hi");

