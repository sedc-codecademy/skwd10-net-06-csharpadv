namespace AnonymousMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            // ---------- Anonymous methods ---------- //

            // a.k.a. methods that only have body defined,
            // that can be captured in variables and passed
            // as parameters as any other variable

            // list of names
            List<string> names = new List<string>()
            {
                "Bob", "Jill", "Wayne", "Greg", "John", "Anne"
            };
            
            // empty list of names
            List<string> empty = new List<string>();

            // ---------- Find method ---------- //

            // The Find method is probably a bad example in the context
            // of this lesson, but it's included in the subject's
            // materials, so let's cover it.
            //
            // will return the element that matches the predicate.
            // note the "predicate" part here - if you check the
            // type of argument that the Find method expects,
            // you will see Find(Predicate<string> match). Don't
            // let this confuse you since Predicate<T> is equivalent
            // to Func<T, bool>, as in a Func with a generic input
            // parameter and bool return type
            string foundBob = names.Find(name => name == "Bob");

            Console.WriteLine($"foundBob: {foundBob}");

            // here's how you would convert a func to a predicate
            Func<string, bool> foundBobFunc = name => name == "Bob";
            Predicate<string> foundBobPredicate = new Predicate<string>(foundBobFunc);

            // if you try to use the func directly, it will show you an error.
            // Find is not a LINQ method - it's a method defined for the List<T>
            // collection and it uses Predicate<T> instead of Func<T, bool>.
            // In practice, it has the same behavior as FirstOrDefault in LINQ
            // context.
            
            // string invalidFoundBob = names.Find(foundBobFunc);
            
            // using the predicate that we created by converting the Func will work
            string foundBob2 = names.Find(foundBobPredicate);

            Console.WriteLine($"foundBob2: {foundBob2}");

            // similarly to Func<string, bool>, we can directly instantiate a predicate...
            Predicate<string> foundBobPredicate2 = name => name == "Bob";

            // ... and use it with the Find method
            string foundBob3 = names.Find(foundBobPredicate2);

            Console.WriteLine($"foundBob3: {foundBob3}");

            // ---------- Simple Func usage ---------- //

            // Func is a type of anonymous methods that can optionally
            // have input parameters, but it's most important feature
            // is that it ALWAYS defines a return type. It is equivalent
            // to any method that has a return type set instead of void
            //
            // here we define a simple Func anonymous method that
            // checks whether the names collection is empty. In
            // this form, this Func is tied to the context where
            // the collection names resides.
            Func<bool> isNamesEmpty = () => names.Count == 0;
            Console.WriteLine($"IsNamesEmpty: {isNamesEmpty()}");

            // isNamesEmpty is a short-form version of Func. This form
            // is adequate when you need a simple check. If you need
            // more logic that would not make sense in one line, you
            // can use the long form of it.
            // The following is equivalent to isNamesEmpty
            Func<bool> isNamesEmptyLong = () =>
            {
                return names.Count == 0;
            };
            Console.WriteLine($"isNamesEmptyLong: {isNamesEmptyLong()}");

            // if we want to make a more general-purpose Func
            // for checking whether a collection is empty, we
            // can add an input parameter to the mix
            Func<List<string>, bool> isCollectionEmpty = collection => collection.Count == 0;

            // this Func we can use for both of our collections defined above
            Console.WriteLine($"isCollectionEmpty(names): {isCollectionEmpty(names)}");
            Console.WriteLine($"isCollectionEmpty(empty): {isCollectionEmpty(empty)}");

            // The sum example:
            Func<int, int, int> sum = (x, y) => x + y;
            Console.WriteLine($"sum: {sum(2, 3)}"); // 2 + 3 = 5

            // ---------- Simple Action usage ---------- //

            // Similarly to Func, Actions can also optionally have
            // input parameters, but its return type is ALWAYS void
            // (does not return anything). It's equivalent to any
            // method with no (void) return type
            Action hello = () => Console.WriteLine("Hello there!");
            hello();

            Action<string, ConsoleColor> printColor = (x, y) =>
            {
                Console.ForegroundColor = y;
                Console.WriteLine(x);
                Console.ResetColor();
            };
            printColor("Error!", ConsoleColor.Red);

            // other example from class06
            // example on how we can create a custom method that takes some
            // "regular" parameter, and a "callback" Action method that would
            // be invoked after some other execution finished
            Greet("Vladimir", str => Console.WriteLine($"How do you do, {str}"));
            Greet("Vladimir", str => Console.WriteLine($"You suck, {str}"));

            // ---------- Simple LINQ ---------- //
            
            // very similar invocation as with the Find method
            var foundBobLinq = names.FirstOrDefault(x => x == "Bob");
            Console.WriteLine($"foundBobLinq: {foundBobLinq}");

            // similarly, we can capture the Func instance into a variable
            // before sending it to the FirstOrDefault method
            Func<string, bool> IsBob = x => x == "Bob";
            string isBobLinq = names.FirstOrDefault(IsBob);
            Console.WriteLine($"isBobLinq: {isBobLinq}");
        }

        /// <summary>
        /// Greets a person. Then invokes callback over the provided name.
        /// </summary>
        /// <param name="name">The name of the greeted person.</param>
        /// <param name="greetCallback">The callback <see cref="Action"/> that will be invoked with <paramref name="name"/> as argument/input parameter.</param>
        public static void Greet(string name, Action<string> greetCallback)
        {
            Console.WriteLine($"Hello, {name}");

            greetCallback(name);
        }
    }
}
