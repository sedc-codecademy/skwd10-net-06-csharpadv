List<string> names = new List<string>()
{
    "Bojan",
    "Miki",
    "David",
    "Zoran",
    "Nikola"
};

Func<int> namesCount = () => names.Count;

Console.WriteLine(namesCount());

Func<int,int,int> sumOfTwoNumbers = (x,y) => x + y;

Console.WriteLine(sumOfTwoNumbers(2,4));

Func<int, int, bool> isSumBiggerThan5 = (x, y) =>
  {
      if (sumOfTwoNumbers(x,y) > 5)
      {
          return true;
      }
      else
      {
          return false;
      }
  };

Console.WriteLine(isSumBiggerThan5(4,4));
Console.WriteLine(isSumBiggerThan5(1,1));

Console.WriteLine("===========================");

Action<List<string>> numberOfElements = (x) => Console.WriteLine(x.Count);

numberOfElements(names);

Action<int, int, int> sumOfThreeNumbers = (x,y,z) => Console.WriteLine($"The sum of three numbers is: {x + y + z}");

sumOfThreeNumbers(2,3,4);

Func<string, bool> containsDavid = (name) => name == "David";
string name = names.FirstOrDefault(containsDavid);

Console.WriteLine($"containsDavid: {name}");

Action<string> printNames = (name) => Console.WriteLine(name);

names.ForEach(printNames);