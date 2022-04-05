List<DateTime> nonWorkingDays = new List<DateTime>()
{
    new DateTime(2001, 1, 1),
    new DateTime(2001, 1, 7),
    new DateTime(2001, 4, 20),
    new DateTime(2001, 5, 1),
    new DateTime(2001, 5, 25),
    new DateTime(2001, 8, 3),
    new DateTime(2001, 9, 8),
    new DateTime(2001, 10, 12),
    new DateTime(2001, 10, 23),
    new DateTime(2001, 12, 8)
};

do
{

    Console.WriteLine("Enter day for date");
    string dayInput = Console.ReadLine();

    bool isDayParsed = int.TryParse(dayInput, out int dayParsed);

    if (!isDayParsed)
    {
        Console.WriteLine("Invalid input for day day");
        return;
    }

    Console.WriteLine("Enter month for date");
    string monthInput = Console.ReadLine();

    bool isMonthParsed = int.TryParse(monthInput, out int monthParsed);

    if (!isMonthParsed)
    {
        Console.WriteLine("Invalid input for month");
        return;
    }

    Console.WriteLine("Enter year for date");
    string yearInput = Console.ReadLine();

    bool isYearParsed = int.TryParse(yearInput, out int yearParsed);

    if (!isYearParsed)
    {
        Console.WriteLine("Invalid input for year");
        return;
    }

    DateTime date = new DateTime(yearParsed, monthParsed, dayParsed);

    foreach (DateTime nonWorkingDay in nonWorkingDays)
    {
        if (date.Day == nonWorkingDay.Day && date.Month == nonWorkingDay.Month)
        {
            Console.WriteLine($"{date} is a non working day");
        }
    }

    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
    {
        Console.WriteLine($"{date} is on weekend {date.DayOfWeek}");
    }
    else
    {
        Console.WriteLine($"{date} is a working day");
    }

    Console.WriteLine("Check another date? y/n");

} while (Console.ReadLine().ToLower() == "y");