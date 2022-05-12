namespace ObjectLifecycle
{
    class Human
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
