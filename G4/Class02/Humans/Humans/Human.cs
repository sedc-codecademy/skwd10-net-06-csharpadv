namespace Humans
{
    /// <summary>
    /// An abstract class defining the concept of a human. Implements IHuman
    /// </summary>
    internal abstract class Human : IHuman
    {
        public string FullName { get; set; }
        
        public int Age { get; set; }
        
        public long Phone { get; set; }
        // Abstract method, will require the child class to provide implementation
        
        public abstract string GetInfo();
        
        public Human(string fullname, int age, long phone)
        {
            FullName = fullname;
            Age = age;
            Phone = phone;
        }

        // Not abstract method will be inherited as is
        public void Greet(string name)
        {
            Console.WriteLine($"Hey there {name}! My name is {FullName}!");
        }
    }
}
