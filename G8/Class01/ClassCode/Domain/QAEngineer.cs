using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class QAEngineer : Person, IDeveloper, ITester
    {
        public List<string> TestingFrameworks { get; set; }
        public QAEngineer(string firstName, string lastName, int age, long phoneNumber, List<string> testintFrameworks)
            :base(firstName, lastName, age, phoneNumber)
        {
            TestingFrameworks = testintFrameworks;
        }
        public void Code()
        {
            Console.WriteLine("QA is coding...");
        }

        public override string GetInfo()
        {
             return $"{FirstName} {LastName} {Age}";
        }

        public void TestFeatures()
        {
            Console.WriteLine("Testing features...");
        }
    }
}
