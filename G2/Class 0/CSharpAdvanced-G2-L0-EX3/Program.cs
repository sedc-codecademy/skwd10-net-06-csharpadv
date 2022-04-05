
string option;
double computerWins = 0;
double playerWins = 0;
double totalGames = 0;
do
{
    PrintMenu();
    option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.WriteLine("You have chosen to play");
            int outcome = PlayGame();

            if (outcome == 1)
            {
                playerWins += 1;
            }
            else if (outcome == 2)
            {
                computerWins += 1;
            }

            totalGames += 1;
            break;
        case "2":
            Console.WriteLine("You have chosen to see the stats");
            ShowStats(computerWins, playerWins, totalGames);
            break;
        case "3":
            Console.WriteLine("You chose to exit");
            break;
    }
}
while (option != "3");

void ShowStats(double computerWins, double playerWins, double totalGames)
{
    Console.WriteLine($"Computer Wins: {computerWins} Player Wins: {playerWins}");
    Console.WriteLine($"The player win percentage is {string.Format("{0:P2}", playerWins/(totalGames * 100))}");
}

int PlayGame()
{
    List<string> options = new List<string>() { "rock", "paper", "scissors" };
    Dictionary<Tuple<string, string>, int> outcome = new Dictionary<Tuple<string, string>, int>()
    {
        { Tuple.Create("rock", "rock"),  0 },
        { Tuple.Create("rock", "scissors"),  1 },
        { Tuple.Create("scissors", "rock"),  2 },
        { Tuple.Create("scissors", "scissors"),  0 },
        { Tuple.Create("scissors", "paper"),  1 },
        { Tuple.Create("paper", "scissors"),  2 },
        { Tuple.Create("paper", "paper"),  0 },
        { Tuple.Create("paper", "rock"),  1 },
        { Tuple.Create("rock", "paper"),  2 },
       
    };

    // rock beats scissros 1
    // scissors cuts paper 2
    // paper beats rock
    // equals 
    // equals -> 0
    // user wins -> 1
    // computer wins -> 2

    Console.WriteLine("User, enter rock,paper or scissors");
    string userSelection = Console.ReadLine().ToLower();

    if (!options.Contains(userSelection))
    {
        Console.WriteLine("Invalid input, exiting play");
        return -1;
    }

    Console.WriteLine("Computer is choosing move");

    Random random = new Random();
    int computerSelectionIndex = random.Next(0, 3); // Next() generates a number between 0 and 3 without including 3 in the range
    string computerSelection = options[computerSelectionIndex];

    Console.WriteLine($"User choice is {userSelection} and computer choice is {computerSelection}");

    int outcomeValue = outcome[Tuple.Create(userSelection, computerSelection)];

    if (outcomeValue == 0)
    {
        Console.WriteLine("DRAW!");
    }
    else if (outcomeValue == 1)
    {
        Console.WriteLine("User wins");
 
    }
    else
    {
        Console.WriteLine("Computer Wins");
    }

    return outcomeValue;
}

static void PrintMenu()
{
    Console.WriteLine("Pick Option:\n1) Play \n2) Stats \n3) Exit");
}