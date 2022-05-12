namespace ObjectLifecycle
{
    using System;

    class Program
    {
        /// <summary>
        /// Upon entering each code block (this includes methods), a new frame to the stack
        /// is added.
        /// </summary>
        static void Main(string[] args)
        {
            // this value is stored in the stack
            int testInt = 123;

            // create new frame for method
            CreateAndPrintHuman();
            // after ending method code block, remove
            // the top frame from the stack (the one
            // created by entering the method's code
            // block)

            // Uncomment this to fill up the stack
            // and get StackOverflowException
            //BadRecursion();

            Console.WriteLine(testInt);
        }
        // after exiting Main()'s code block, remove
        // the top frame from the stack

        private static void CreateAndPrintHuman()
        {
            // store the object bob in the heap and
            // store a reference/address in current
            // method's stack frame
            Human bob = new Human("Bob", "Bobsky");

            // bob object is called to be printed,
            // find the object in the heap using its
            // address in the current stack frame
            Console.WriteLine($"Hello everyone! This is {bob.FirstName} {bob.LastName}");
        }

        /// <summary>
        /// Recursion methods would create a new
        /// stack frame for each self-invocation -
        /// a badly terminated recursive method will
        /// easily fill up the whole stack.
        /// </summary>
        private static void BadRecursion()
        {
            BadRecursion();
        }
    }
}
