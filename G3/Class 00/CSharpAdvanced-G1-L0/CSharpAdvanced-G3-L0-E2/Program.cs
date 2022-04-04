// See https://aka.ms/new-console-template for more information
List<DateTime> holidays = new List<DateTime>()
{
    new DateTime(2022, 1, 1),
    new DateTime(2022, 1, 7),
    new DateTime(2022, 4, 20),
    new DateTime(2022, 1, 5),
    new DateTime(2022, 5, 25),
    new DateTime(2022, 8, 3),
    new DateTime(2022, 9, 8),
    new DateTime(2022, 10, 12),
    new DateTime(2022, 10, 23),
    new DateTime(2022, 12, 18),
};

do
{
    Console.WriteLine("Please enter date");
    string dateString = Console.ReadLine();

    bool isParsed = DateTime.TryParse(dateString, out DateTime parsedDate);


    if (isParsed)
    {
        if (parsedDate.DayOfWeek == DayOfWeek.Saturday || parsedDate.DayOfWeek == DayOfWeek.Sunday || IsHoliday(parsedDate))
        {
            Console.WriteLine("The entered day is not working");
        }
        else
        {
            Console.WriteLine("The enterd day is working");
        }
    }

    Console.WriteLine("Would you like to continue? Y/N");
    string shouldContiue = Console.ReadLine();
    if (shouldContiue.ToLower() == "n")
    {
        break;
    }
}while (true);

bool IsHoliday(DateTime parsedDate)
{
    foreach (DateTime holiday in holidays)
    {
        if (holiday.Month == parsedDate.Month && holiday.Day == parsedDate.Day)
        {
            return true;
        }
    }

    return false;
}