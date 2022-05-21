using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPractices.GoodPractices
{
    // Bad Example
    class user
    {
        private readonly string userpath = @"C:\users";
        public int id;
        public string name;
        public bool logged;

        public void printuser()
        {
            // .. code
        }
        public void changeid(int NewID)
        {
            id = NewID;
        }
    }

    // Good Example
    class User
    {
        private readonly string _userpath = @"C:\users";
        public int Id;
        public string Name;
        public bool Logged;

        public void PrintUser()
        {
            // .. code
        }
        public void ChangeId(int newId)
        {
            Id = newId;
        }
    }

    //Exceptions
    //BadExample
    class LoginProblem : Exception
    {
        // ...code
    }
    //Good Example
    class LoginException : Exception
    {
        // ...code
    }

    // Interfaces
    // Bad Example
    public interface Vehicle
    {
        void Drive();
    }
    // Good Example
    public interface IVehicle
    {
        void Drive();
    }
}
