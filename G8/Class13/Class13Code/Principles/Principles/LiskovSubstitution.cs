using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principles.Principles
{
    // Bad Example

    public class StringComparing
    {
        protected string _firstString;
        protected string _secondString;
        public StringComparing(string str1, string str2)
        {
            _firstString = str1;
            _secondString = str2;
        }

        public void Compare()
        {
            if(_firstString.Length > _secondString.Length)
            {
                Console.WriteLine("The first is larger");
            }
            else if(_firstString.Length < _secondString.Length)
            {
                Console.WriteLine("The second is larger");
            }
            else
            {
                Console.WriteLine("They are the same");
            }
        }
    }

    public class LetterStringComparing : StringComparing
    {
        public LetterStringComparing(string str1, string str2) : base(str1, str2){ }

        public void Compare()
        {
            if(_firstString.First() == _secondString.First())
            {
                Console.WriteLine("They start with the same letter");
            }
            else
            {
                Console.WriteLine("They don't start with the same letter");
            }
        }
    }

    public class App
    {
        public void Run()
        {
            //Work
            Console.WriteLine("Example 1:");
            StringComparing strComp1 = new StringComparing("Bob", "Jill");
            strComp1.Compare();
            LetterStringComparing letterStrComp1 = new LetterStringComparing("Bob", "Jill");
            letterStrComp1.Compare();
            //Problem
            StringComparing strCompPolymorph1 = new LetterStringComparing("Bob", "Jill");
            strCompPolymorph1.Compare();
        }
    }

    // Good Example
    public abstract class StringComparingGood
    {
        protected string _firstString;
        protected string _secondString;
        public StringComparingGood(string str1, string str2)
        {
            _firstString = str1;
            _secondString = str2;
        }

        public abstract void Compare();
    }

    public class LenghthStringComparing : StringComparingGood
    {
        public LenghthStringComparing(string str1, string str2) : base(str1, str2) { }

        public override void Compare()
        {
            if (_firstString.Length > _secondString.Length)
            {
                Console.WriteLine("The first is larger");
            }
            else if (_firstString.Length < _secondString.Length)
            {
                Console.WriteLine("The second is larger");
            }
            else
            {
                Console.WriteLine("They are the same");
            }
        }
    }

    public class LetterStringComparingGood : StringComparingGood
    {
        public LetterStringComparingGood(string str1, string str2) : base(str1, str2) { }

        public override void Compare()
        {
            if (_firstString.First() == _secondString.First())
            {
                Console.WriteLine("They start with the same letter");
            }
            else
            {
                Console.WriteLine("They don't start with the same letter");
            }
        }
    }

    public class AppGood
    {
        public void Run()
        {
            // Works
            Console.WriteLine("Example 2:");
            LenghthStringComparing strComp2 = new LenghthStringComparing("Bob", "Jill");
            strComp2.Compare();
            LetterStringComparingGood letterStrComp2 = new LetterStringComparingGood("Bob", "Jill");
            letterStrComp2.Compare();
            // Not a Problem any more
            StringComparingGood strCompPolymorph2 = new LetterStringComparingGood("Bob", "Jill");
            StringComparingGood strCompPolymorph3 = new LenghthStringComparing("Bob", "Jill");
            strCompPolymorph2.Compare();
            strCompPolymorph3.Compare();
        }
    }
}
