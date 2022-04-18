using ExtensionMethods.Helpers;

#region String Extension Methods
string text = "C# Advanced is an awesome subject with great demos and activities!";

string shortDescription = StringHelper.Shorten(text, 6);
Console.WriteLine(shortDescription);

string shortDescription1 = text.Shorten(6).QuoteString();
Console.WriteLine(shortDescription1);

Console.ReadLine();
#endregion

#region Generic Extension Method
List<string> strings = new List<string>() { "str1", "str2", "str3" };
List<int> ints = new List<int>() { 1, 2, 3 };
List<bool> bools = new List<bool>() { true, false, true };

strings.GoThrough();
strings.GetInfo();
ints.GoThrough();
ints.GetInfo();
bools.GoThrough();
bools.GetInfo();

strings.TestMethod().GetInfo();

#endregion
