// See https://aka.ms/new-console-template for more information

using System.Globalization;

#region Detect word in text
List<string> words = new List<string>();
string insertedWord = String.Empty;

Console.WriteLine("Pleasse insert word or insert \"x\" for end: ");
while (insertedWord != "x")
{
    insertedWord = Console.ReadLine();
    if (insertedWord != "x")
    {
        words.Add(insertedWord);
    }
}

Console.WriteLine("Please insert text: ");
string text = Console.ReadLine();

foreach (string word in words)
{
    int count = text.Split(word).ToList().Count - 1;
    if (count > 0)
    {
        Console.WriteLine($"The word {word} is found in the text {count} times.");
    }
    else
    {
        Console.WriteLine($"The word {word} is not found in the text.");
    }
}
#endregion Detect word in text

#region Detect working day
//string runAgain = "yes";

//while (runAgain.ToLower() == "yes")
//{
//    List<string> nonWorkingDates = new List<string>() { "1 January", "7 January", "20 April", "1 May", "25 May", "3 August", "8 September", "12 October", "23 October", "8 December" };
//    List<string> dates = new List<string>();
//    string insertedDate = string.Empty;

//    Console.WriteLine("Please insert date in the following format D Month (1 January) for exit type \"x\":");
//    while (insertedDate.ToLower() != "x")
//    {
//        insertedDate = Console.ReadLine();
//        if (insertedDate.ToLower() != "x")
//        {
//            dates.Add(insertedDate);
//        }
//    }

//    foreach (string date in dates)
//    {
//        if (nonWorkingDates.Contains(date))
//        {
//            Console.WriteLine($"The date {date} 2022 is non working day!");
//        }
//        else
//        {
//            try
//            {
//                DateTime parsedDate = DateTime.ParseExact(date + " 2022", "d MMMM yyyy", CultureInfo.InvariantCulture);
//                DayOfWeek day = parsedDate.DayOfWeek;
//                if (day == DayOfWeek.Sunday || day == DayOfWeek.Saturday)
//                {
//                    Console.WriteLine($"The date {date} 2022 is non working day!");
//                }
//                else
//                {
//                    Console.WriteLine($"The date {date} 2022 is working day!");
//                }
//            }
//            catch (Exception)
//            {
//                Console.WriteLine("The inserted date is not in correct format");
//            }
//        }
//    }
//    Console.WriteLine("To run again type \"yes\" to exit type \"no\"");
//    runAgain = Console.ReadLine();
//}
#endregion Detect working day

#region Rock Paper Scissors
//int playerPoints = 0;
//int computerPoints = 0;
//string state = string.Empty;

//while (state.ToLower() != "exit")
//{
//    Console.WriteLine("If you want to play type \"play\", if you want to see result type \"stats\" to exit type\"exit\"");
//    state = Console.ReadLine();
//    switch (state)
//    {
//        case "exit":
//            break;
//        case "play":
//            {
//                Console.WriteLine("For rock type 1");
//                Console.WriteLine("For paper type 2");
//                Console.WriteLine("For scissors type 3");
//                string playerSelected = Console.ReadLine();
//                if (playerSelected == "1" || playerSelected == "2" || playerSelected == "3")
//                {
//                    string computerSelected = new Random().Next(1, 3).ToString();

//                    Console.WriteLine($"Player selected {GetSelection(playerSelected)} and computer selected {GetSelection(computerSelected)}");

//                    if (playerSelected == "1" && computerSelected == "2")
//                    {
//                        computerPoints++;
//                        Console.WriteLine("Computer wins!");
//                    }
//                    else if (playerSelected == "1" && computerSelected == "3")
//                    {
//                        playerPoints++;
//                        Console.WriteLine("Player wins!");
//                    }
//                    else if (playerSelected == "2" && computerSelected == "3")
//                    {
//                        computerPoints++;
//                        Console.WriteLine("Computer wins!");
//                    }
//                    else if (playerSelected == "2" && computerSelected == "1")
//                    {
//                        playerPoints++;
//                        Console.WriteLine("Player wins!");
//                    }
//                    else if (playerSelected == "3" && computerSelected == "1")
//                    {
//                        computerPoints++;
//                        Console.WriteLine("Computer wins!");
//                    }
//                    else if (playerSelected == "3" && computerSelected == "2")
//                    {
//                        playerPoints++;
//                        Console.WriteLine("Player wins!");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Tie!");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Player selection is not valid");
//                }
//                break;
//            }
//        case "stats":
//            Console.WriteLine("============== CURRENT SCORE ==================");
//            Console.WriteLine($"Player {playerPoints} - {computerPoints} Computer");
//            Console.WriteLine("===============================================");
//            Console.WriteLine();
//            break;
//    }
//}

//static string GetSelection(string selecteed)
//{
//    string selected = string.Empty;
//    switch (selecteed)
//    {
//        case "1":
//            selected = "Rock";
//            break;
//        case "2":
//            selected = "Paper";
//            break;
//        case "3":
//            selected = "Scissors";
//            break;
//    }
//    return selected;
//}
#endregion Rock Paper Scissors
