// See https://aka.ms/new-console-template for more information
using Exercise3;

Player petre = new Player() { Name = "Petre" };
Player angel = new Player() { Name = "Angel" };
int matchesPlayed = 0;
//if(menuChosen == 0)
//{
//    throw new Exception("The user input must be a number and not zero");
//}
//else if(menuChosen == 1)
//{
//    //TODO: Should play the game
//}
//else if(menuChosen == 2)
//{
//    //TODO: Should show 
//}
//else
//{
//    //Exit the applicaiton
//}
while (true)
{
    Console.WriteLine("Please enter 1 to play 2 for stats and 3 to exit");
    string userInput = Console.ReadLine();
    int menuChosen = ChooseMenuItem(userInput);
    switch (menuChosen)
    {
        case 0:
            throw new Exception("Wrong input");
            break;
        case 1:
            Play(petre, angel);
            matchesPlayed++;
            continue;
        case 2:
            DisplayStats(petre, angel, matchesPlayed);
            //Show stats
            break;
        default:
            //Close the app
            break;
    }
    if (menuChosen != 1)
        break;
}
Console.ReadLine();


static int ChooseMenuItem(string userInput)
{
    int result = 0;
    bool isValidNumber = int.TryParse(userInput, out result);
    return result;
}

static void Play(Player playerOne, Player playerTwo)
{
    int playerOnePickRandom = new Random().Next(1, 3);
    playerOne.PlayerChoice = (UserChoice)playerOnePickRandom;
    int playerTwoPickRandom = new Random().Next(1, 3);
    playerTwo.PlayerChoice = (UserChoice)playerTwoPickRandom;
    string resultText = DecideWinner(playerOne, playerTwo);
    Console.WriteLine(resultText);
}

static string DecideWinner(Player playerOne, Player playerTwo)
{
    if (playerOne.PlayerChoice == UserChoice.Rock && playerTwo.PlayerChoice == UserChoice.Scissors)
    {
        playerOne.Score++;
        return $"Player {playerOne.Name} won";
    }
    else if (playerOne.PlayerChoice == UserChoice.Rock && playerTwo.PlayerChoice == UserChoice.Paper)
    {
        playerTwo.Score++;
        return $"Player {playerTwo.Name} won";
    }
    else if (playerOne.PlayerChoice == UserChoice.Scissors && playerTwo.PlayerChoice == UserChoice.Paper)
    {
        playerOne.Score++;
        return $"Player {playerOne.Name} won";
    }
    else if (playerOne.PlayerChoice == UserChoice.Scissors && playerTwo.PlayerChoice == UserChoice.Rock)
    {
        playerTwo.Score++;
        return $"Player {playerTwo.Name} won";
    }
    else if (playerOne.PlayerChoice == UserChoice.Paper && playerTwo.PlayerChoice == UserChoice.Scissors)
    {
        playerTwo.Score++;
        return $"Player {playerTwo.Name} won";
    }
    else if (playerOne.PlayerChoice == UserChoice.Paper && playerTwo.PlayerChoice == UserChoice.Rock)
    {
        playerOne.Score++;
        return $"Player {playerOne.Name} won";
    }
    else
    {
        return "It's tie";
    }
}
static void DisplayStats(Player player, Player player2, int matchesPlayed)
{
    Console.WriteLine($"The player {player.Name} has {player.Score} wins");
    Console.WriteLine($"The player {player2.Name} has {player2.Score} wins");
    double playerOneWins = (double)player.Score / (double)matchesPlayed;
    double playerTwoWins = (double)player2.Score / (double)matchesPlayed;
    Console.WriteLine(string.Format("The player {0} has {1:P} wins", player.Name, playerOneWins));
    Console.WriteLine(string.Format("The player {0} has {1:P} wins", player2.Name, playerTwoWins));
}
