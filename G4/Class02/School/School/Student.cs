namespace School
{
    internal class Student : User, IStudent //, IUser can be set here as well, but User already implements it, so redundant
    {
        public List<int> Grades { get; set; }

        public override void PrintUser()
        {
            Console.WriteLine($"Student {Name}'s grades are:");

            foreach (var grade in Grades)
            {
                Console.WriteLine(grade);
            }
        }
    }
}
