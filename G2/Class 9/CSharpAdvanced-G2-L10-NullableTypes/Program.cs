int? number = null;

if (number == null)
{
    number = 0;

    Console.WriteLine(number);
}

decimal? decimalNumber = null;

int validNumber = number ?? 0;


Item item = null;

Console.WriteLine($"{item?.ToString().Length} was printed");

// This is how the null coalescing operator is 'translated'
//if (number == null)
//{
//    return 0;
//}
//else
//{
//    return number;
//}


public class Item
{
    public string Name { get; set; }

    public Item(string name)
    {
        Name = name;
    }


    public int GetNameLength()
    {
        return Name?.Length ?? 0;
    }

    public override string ToString()
    {
        return Name;
    }
}