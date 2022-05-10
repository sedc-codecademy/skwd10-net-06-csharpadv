namespace NullableTypes
{
    using System;

    class Person
    {
        public int Id { get; }
        /// <summary>
        /// This represent a property with a nullable <see cref="int"/> value.
        /// Every value type has its nullable variant - just add a question mark
        /// (?) after the type. This allows this property to be able to take
        /// null as value, and also exposes the <see cref="Nullable{T}.HasValue"/>
        /// property, which can be used as a shortcut to check whether the nullable
        /// variable/property/field value is null.
        /// </summary>
        public int? Score { get; private set; }
        public string Name { get; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void StartGame()
        {
            // Score must be != null
            // to consider game started
            if (Score == null)
                Score = 0;
        }

        public void WinPoint()
        {
            if (!IsGameStarted())
            {
                PrintGameNotStarted();
                return;
            }

            Score++;
            PrintScore();
        }

        public void LosePoint()
        {
            if (!IsGameStarted())
            {
                PrintGameNotStarted();
                return;
            }

            Score--;
            PrintScore();
        }

        public bool IsGameStarted()
        {
            return Score != null; // equivalent to Score.HasValue
        }

        private void PrintGameNotStarted()
        {
            Console.WriteLine("Game has not been started.");
        }

        private void PrintScore()
        {
            Console.WriteLine($"Score is {Score}");
        }
    }
}
