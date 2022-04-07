using CSharpAdvanced_G2_L1_Interfaces.Interfaces;

namespace CSharpAdvanced_G2_L1_Interfaces.Entities
{
    public class Employee : IWork // Employee IMPLEMENTS IWork
    {
        public string Name { get; set; }

        public int WorkingHours { get; set; }

        public Employee(string name, int workingHours)
        {
            Name = name;
            WorkingHours = workingHours;
        }

        public void DoWork()
        {
            Console.WriteLine($"{Name} is doing work");
        }
    }
}
