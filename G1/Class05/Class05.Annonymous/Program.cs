List<string> list = new List<string>() { "string 3","string 4","string 5"};
List<string> list2 = new List<string>();

#region Finctions with Lambda
//string result = list.Find(x => x == "string 3");

//Func<bool> isListEmpty = () => list2.Count == 0;

//Func<List<string>, bool> isList1Empty = (x) => x.Count == 0;

//Func<int, int, int> multiply = (a, b) => a * b;

Func<int, int, bool> checkLarger = (a, b) =>
 {
     if (a > b)
     {
         return true;
     }
     return false;
 };

//if(isList1Empty(list2))
//{
//    Console.WriteLine("Listata e prazna");
//}
//else
//{
//    Console.WriteLine("Listata ne e prazna");
//}

//Console.WriteLine(multiply(2,4));

//if(checkLarger(3,7))
//{
//    Console.WriteLine("3 is larger than 7");
//}
//else
//{
//    Console.WriteLine("3 is not larger than 7");
//}

Func<string, bool> IsBob = x => x == "string 3";
string foundJill = list.FirstOrDefault(IsBob);
Console.WriteLine(foundJill);
#endregion

#region Action

Action hello = () => Console.WriteLine("Hello!!!");

hello();

Action<string> printRed = (text) =>
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(text);
    Console.ResetColor();
};

printRed("Ovoj text treba da e crven!");

Action<string, ConsoleColor> printColor = (text, color) =>
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
};

printColor("Ovoj text treba da e vo boja", ConsoleColor.Green);

#endregion