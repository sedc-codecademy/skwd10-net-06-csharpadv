// See https://aka.ms/new-console-template for more information
List<DateTime> publicHolidays = new List<DateTime>()
            {
                new DateTime(2021,01,01),
                new DateTime(2021,01,07),
                new DateTime(2021,04,20),
                new DateTime(2021,05,01),
                new DateTime(2021,05,25),
                new DateTime(2021,08,02),
                new DateTime(2021,09,08),
                new DateTime(2021,10,12),
                new DateTime(2021,10,23),
                new DateTime(2021,12,08)
            };
string dateInput = string.Empty;
string userInput = string.Empty;
do
{
    Console.WriteLine("Wellcome to the working day or not app");
    Console.WriteLine("Please enter a date to check if it's a working day or not");
    dateInput = Console.ReadLine();
    bool isInputValidDate = DateTime.TryParseExact(dateInput, new string[] { "dd.MM.yyyy", "dd-MM-yyyy" }, null,
                                                System.Globalization.DateTimeStyles.None,
                                                out DateTime realdate);
    if (isInputValidDate)
    {
        PrintIfDateisWorkingDay(realdate, publicHolidays);
    }
    else
    {
        throw new Exception("The date you entered was not a valid date");
    }
    Console.WriteLine("Would you like to check an other date?");
    Console.WriteLine("Press Y/y if yes or any other key to stop");
    userInput = Console.ReadLine();
} while (userInput == "y" || userInput == "Y");


static bool IsWeekend(DateTime date)
{
    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        return true;

    return false;
}

static void PrintIfDateisWorkingDay(DateTime date, List<DateTime> publicHolidays)
{
    bool isPublicHoliday = false;
    foreach (DateTime dateInHolidays in publicHolidays)
    {
        if (date == dateInHolidays)
            isPublicHoliday = true;
    }

    if (isPublicHoliday || IsWeekend(date))
    {
        Console.WriteLine("The date is not working date");
    }
    else
    {
        Console.WriteLine("It is a working day and you have to go to work");
    }
}
