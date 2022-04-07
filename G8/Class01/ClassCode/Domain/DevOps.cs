using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DevOps : Person, IDeveloper, IOperations
    {
        public bool AWSCertificied { get; set; }
        public bool AzureCertificied { get; set; }

        public DevOps(string firstName, string lastName, int age, long phoneNumber, bool aws, bool azure)
            : base(firstName, lastName, age, phoneNumber)
        {
            AWSCertificied = aws;
            AzureCertificied = azure;
        }
        //IOperations
        public bool CheckInfrastructures(int status)
        {
            if (status >= 200 && status <= 299)
                return true;
            return false;
        }

        //IDeveloper
        public void Code()
        {
            Console.WriteLine("DevOps is coding...");
        }
        //Person
        public override string GetInfo()
        {
            string awsCertified = AWSCertificied ? "has AWS certificate" : "does not have AWS certificate";
            string azureCertified = AzureCertificied ? "has Azure certificate" : "does not have Azure certificate";
            return $"{FirstName} {LastName} {awsCertified}, {azureCertified}";
        }
    }
}
