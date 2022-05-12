using System;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Person bob = new Person(1, "Bob");

            Console.WriteLine($"Did Bob start playing: {bob.IsGameStarted()}");

            bob.StartGame();

            // if Person.Score was not nullable,
            // and our prerequisite for whether the
            // game was started was Score == 0, by losing
            // points equal to the won ones we would get
            // to a "not started" state again, which won't
            // be correct. Having null as a starting state
            // of Person.Score makes it easy to decide whether
            // the game started - if it has any value other than
            // null, the game is started
            bob.WinPoint();
            bob.WinPoint();
            bob.LosePoint();
            bob.LosePoint();

            Console.WriteLine($"Did Bob start playing: {bob.IsGameStarted()}");
        }
    }
}
