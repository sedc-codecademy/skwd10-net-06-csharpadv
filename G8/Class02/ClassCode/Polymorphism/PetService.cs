using Polymorphism.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class PetService
    {
        // Polymorphism ( Method overloading )
        // Both methods have the same name
        // Their signature is different
        public void PetStatus(Dog pet, string ownerName)
        {
            Console.WriteLine($"Hey there {ownerName}");
            if (pet.IsGoodBoi) Console.WriteLine("This dog is good boi :)");
            else Console.WriteLine("This dog is not really a good boi :(");
        }
        // Signature is different when the order of the properties do not match
        public void PetStatus(string ownerName, Dog pet)
        {
            Console.WriteLine($"Hey there {ownerName}. Happy to see you again!");
            if (pet.IsGoodBoi) Console.WriteLine("This dog is still good boi :)");
            else Console.WriteLine("This dog is still not really a good boi :(");
        }
        // Sugnature is different if the property types do not match
        public void PetStatus(Cat pet, string ownerName)
        {
            Console.WriteLine($"Hey there {ownerName}");
            if (pet.IsLazy) Console.WriteLine("This cat is really lazy :(");
            else Console.WriteLine("This cat is cool and not lazy at all :)");
        }
        // Sugnature is different if the number of properties do not match
        public void PetStatus(Cat pet)
        {
            Console.WriteLine("Hey, a cat with no owner.");
            if (pet.IsLazy) Console.WriteLine("This cat is really lazy :(");
            else Console.WriteLine("This cat is cool and not lazy at all :)");
        }
    }
}
