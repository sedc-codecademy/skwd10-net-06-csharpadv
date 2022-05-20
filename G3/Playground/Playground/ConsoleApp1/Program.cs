using ConsoleApp1;

Func<int, int> Compose(Func<int, int> first, Func<int, int> second)
    => x => first(second(x));


// x => 2x+1

int AddOne(int x) => x + 1;
int Double(int x) => x * 2;

var DvaXPlusEden = Compose(AddOne, Double);

Console.WriteLine(DvaXPlusEden(3));
Console.WriteLine(string.Empty.PadLeft(20, '-'));
//-------------

var fourNumbersList = new List<int> { 1, 2, 3, 4 };
var emptyList = new List<int>();
var singleZeroList = new List<int> { 0 };

fourNumbersList.FirstOrDefault(x =>
{
    // will be called four times
    Console.WriteLine($"called with x = {x}");
    return false;
});

fourNumbersList.FirstOrDefault(x =>
{
    // will be called four times
    Console.WriteLine($"called with x = {x}");
    return true;
});


Console.WriteLine(string.Empty.PadLeft(20, '-'));
//-------------

Person weko = new Programmer
{
    FirstName = "Wekoslav",
    LastName = "Stefanovski",
    Language = "Typescript"
};
Console.WriteLine(weko);

Person igor = new Programmer
{
    FirstName = "Igor",
    LastName = "Nikoloski",
    Language = "C#"
};

var person = weko;

var result = person switch
{
    { FirstName: "Wekoslav" } => "Senior",
    { FirstName: "Igor" } => "Junior",
    _ => "Don't know"
};

Console.WriteLine(result);

//-------------
Console.WriteLine(string.Empty.PadLeft(20, '-'));

var playerOne = RPS.Paper;
var playerTwo = RPS.Rock;

//var rpsGame = new RPSGame
//{
//    PlayerOne = playerOne,
//    PlayerTwo = playerTwo
//};

// var rpsGame = new RPSGameRecord(playerOne, playerTwo);

var rpsGame = (PlayerOne: playerOne, PlayerTwo: playerTwo);

Console.WriteLine(rpsGame.Item1);
Console.WriteLine(rpsGame.PlayerOne);

//var rpsResult = rpsGame switch
//{
//    { PlayerOne: RPS.Paper, PlayerTwo: RPS.Rock } => "Player One Wins",
//    { PlayerOne: RPS.Paper, PlayerTwo: RPS.Scissors } => "Player Two Wins",
//    { PlayerOne: RPS.Rock, PlayerTwo: RPS.Scissors } => "Player One Wins",
//    { PlayerOne: RPS.Rock, PlayerTwo: RPS.Paper } => "Player Two Wins",
//    { PlayerOne: RPS.Scissors, PlayerTwo: RPS.Paper } => "Player One Wins",
//    { PlayerOne: RPS.Scissors, PlayerTwo: RPS.Rock } => "Player Two Wins",
//    _ => "Tie"
//};

//Console.WriteLine(rpsResult);

var rpsResult = (playerOne, playerTwo, 11) switch
{
    (_, _, 7) => "The only way to win is not to play",
    (RPS.Paper, RPS.Rock, _) => "Player One Wins",
    (RPS.Paper, RPS.Scissors, _) => "Player Two Wins",
    (RPS.Rock, RPS.Scissors, _) => "Player One Wins",
    (RPS.Rock, RPS.Paper, _) => "Player Two Wins",
    (RPS.Scissors, RPS.Paper, _) => "Player One Wins",
    (RPS.Scissors, RPS.Rock, _) => "Player Two Wins",
    _ => "Tie"
};

Console.WriteLine(rpsResult);

//-------------
Console.WriteLine(string.Empty.PadLeft(20, '-'));

// or condition

var boolOne = false;
var boolTwo = true;

var boolThree = (boolOne, boolTwo) switch
{
    (true, _) => true,
    (_, true) => true,
    _ => false,
};

var boolFour = boolOne || boolTwo;

Console.WriteLine(boolThree);
Console.WriteLine(boolFour);

//-------------
Console.WriteLine(string.Empty.PadLeft(20, '-'));

var x = 3;

var sign = x switch
{
    > 0 => 1,
    < 0 => -1,
    _ => 0,
};

var isZero = x switch
{
    > 0 or < 0 => false,
    _ => true,
};

//var cleanValue = input switch
//{
//    checkOne => throw new ExceptionOne(),
//    checkOne => throw new ExceptionOne(),
//    checkOne => throw new ExceptionOne(),
//    checkOne => throw new ExceptionOne(),
//    checkOne => throw new ExceptionOne(),
//    _ => input.Trim()
//};

//-------------
Console.WriteLine(string.Empty.PadLeft(20, '-'));

StarbucksOptions flavor;

//flavor = StarbucksOptions.Vanilla | StarbucksOptions.ExtraShot;
flavor = (StarbucksOptions)12;

flavor.HasFlag(StarbucksOptions.SkimMilk);

Console.WriteLine(flavor);