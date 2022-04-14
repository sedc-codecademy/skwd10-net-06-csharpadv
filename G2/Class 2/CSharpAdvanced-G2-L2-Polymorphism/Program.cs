// See https://aka.ms/new-console-template for more information
using CSharpAdvanced_G2_L2_Polymorphism.Entities;
using CSharpAdvanced_G2_L2_Polymorphism.Helpers;

Console.WriteLine("Hello, World!");


User user = new User("Miki");

user.SayHello();

user.SayHello(LanguageHelper.MACEDONIAN);