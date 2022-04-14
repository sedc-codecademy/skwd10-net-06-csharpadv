// See https://aka.ms/new-console-template for more information
using CSharpAdvanced_G2_L3_GenericsAndExtensions.Entities;

Console.WriteLine("Hello, World!");


List<string> stringList = new List<string>();

Order orderOne = new Order(1);
Order orderOneCopy = new Order(1);
Order orderTwo = new Order(2);

Cart cartOne = new Cart(1);

// orderOne.IsEqualTo(cartOne);