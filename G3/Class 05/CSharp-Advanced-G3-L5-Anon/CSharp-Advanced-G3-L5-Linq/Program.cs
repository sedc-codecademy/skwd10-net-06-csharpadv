// See https://aka.ms/new-console-template for more information

List<int> intList = new List<int> { 5, 6, 1, 4, 19, 32, 8, 14 };

var largerThanTen = intList.Where(IsLargerThanTen).ToList();


largerThanTen.ForEach(number => Console.WriteLine(number));

static bool IsLargerThanTen(int number)
{
    return number > 10;
}

List<string> stringList = new List<string> { "12", "2", "6", "23", "44", "5", "8", "15", "dfsdfsd" };

List<int> convertedList = stringList.Select((stringNumber) =>
{
    int number;

    int.TryParse(stringNumber, out number);

    return number;
}).ToList();

convertedList.ForEach(x=> Console.WriteLine(x));
