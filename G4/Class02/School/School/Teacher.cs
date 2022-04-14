namespace School
{
    internal class Teacher : User, ITeacher //, IUser can be set here as well, but User already implements it, so redundant
    {
        public string Subject { get; set; }

        public override void PrintUser()
        {
            Console.WriteLine($"Teacher {Name}'s subject is {Subject}");
        }
    }
}
