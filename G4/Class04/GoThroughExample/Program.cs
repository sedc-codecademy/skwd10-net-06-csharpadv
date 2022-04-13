using System.Collections;

namespace GoThroughExample // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 3, 5, 7 };
            List<string> strings = new List<string> { "Bob", "Jill", "Greg" };

            GoThroughStrings(strings);
            GoThroughInts(ints);
            GoThroughObjects(strings.Cast<object>().ToList());
            GoThrough(ints);
            GoThrough(strings);

            var list = new ArrayList();
            list.Add(1);
            list.Add("test");

            GoThroughArrayList(list);

            GenericListHelper<int> intHelper = new GenericListHelper<int>();
            GenericListHelper<string> stringHelper = new GenericListHelper<string>();

            intHelper.GetInfo(ints);
            stringHelper.GetInfo(strings);

            NonGenericListHelper nonGenericHelper = new NonGenericListHelper();

            nonGenericHelper.GoThrough(ints);
            nonGenericHelper.GoThrough(strings);

            IntListHelper intListHelper = new IntListHelper();
            intListHelper.GetInfo(ints);

            // the objects in this list will be printed according to the implementation
            // of the override of object.ToString()
            var prettyPrintedObjectList = new List<PrettyPrintedComplexObject> 
            {
                new PrettyPrintedComplexObject() { Name = "Pretty object", Description = "So pretty!" },
                new PrettyPrintedComplexObject() { Name = "Another pretty object", Description = "So shiny!" }
            };

            // on the other hand, the objects in this list will output the default
            // behavior 
            var uglyPrintedObjectList = new List<UglyPrintedComplexObject> 
            {
                new UglyPrintedComplexObject() { Name = "Ugly object", Description = "Ugly - ew! Good thing this description won't be printed!" },
                new UglyPrintedComplexObject() { Name = "Very ugly object", Description = "Very ugly - YUCK! Good thing this description won't be printed either!" }
            };

            GoThrough(prettyPrintedObjectList);
            GoThrough(uglyPrintedObjectList);
        }

        /// <summary>
        /// String list specific implementation
        /// </summary>
        public static void GoThroughStrings(List<string> strings)
        {
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Int list specific implementation
        /// </summary>
        public static void GoThroughInts(List<int> ints)
        {
            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// List of objects variant
        /// </summary>
        public static void GoThroughObjects(List<object> objects)
        {
            foreach (var item in objects)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Generic implementation that should work with any
        /// object type, as long as the object has proper
        /// implementation of ToString()
        /// </summary>
        public static void GoThrough<T>(List<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Variant with ArrayList. Note that, while ArrayList
        /// is an elegant way to provide the functionalities of
        /// a generic collection, it's usage is discouraged unless
        /// you are doing a simple implementation because it's impossible
        /// to predict the element types, and for some more advanced
        /// operations, you will need to have a lot of conditionals
        /// to be able to cover all possible types.
        /// </summary>
        public static void GoThroughArrayList(ArrayList items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    /// <summary>
    /// Sample complex object to illustrate that non-constrained
    /// generics can be used over complex objects as well. Note
    /// the override of the ToString() method - it allows us to
    /// override the default result we would get when printing
    /// through Console.WriteLine().
    /// </summary>
    class PrettyPrintedComplexObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Description}";
        }
    }

    /// <summary>
    /// Compared to PrettyPrintedComplexObject which shares the
    /// same property structure but overrides ToString(),
    /// UglyPrintedComplexObject falls back to the default
    /// object.ToString() behaviour and the output when trying
    /// to print it is not that user-friendly/readable.
    /// </summary>
    class UglyPrintedComplexObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}