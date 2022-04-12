// See https://aka.ms/new-console-template for more information

using CSharp_Advanced_G3_L3_Extensions.Extensions;

Console.WriteLine(StringExtensions.DeleteLastCharacterClassic("String to shorten"));

string textToShorten = "Some string value";
string shortString = StringExtensions.DeleteLastCharacter(textToShorten);

Console.WriteLine(textToShorten.DeleteLastCharacter());

string textToQuote = "Quoted text";
Console.WriteLine(textToQuote.AddQuatations());

List<string> list = new List<string>() { "First", "Second", "Third", "Fourth", "Fifth" };
list.PrintElements();
