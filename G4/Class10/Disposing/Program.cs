namespace Disposing
{
    class Program
    {
        static void Main(string[] args)
        {
            // invoke helper method with explicit Dispose()
            FileHelper.AppendTextInFile("file1.txt", "Hello G4!");

            // invoke method that uses using keyword instead. This will implicitly
            // invoke Dispose
            FileHelper.AppendTextInFileSafe("file1.txt", "How are you this Saturday?");

            // our custom StreamWriter wrapper implementation
            // this usage explicitly calls Dispose method
            // also note that here we specify a value for the
            // optional parameter in the OutWriter constructor
            OutWriter writer1 = new OutWriter("file3.txt", false);

            writer1.Write("line 1");
            writer1.Write("line 2");

            writer1.Dispose();

            // this usage disposes our new writer instance automatically
            // at the end of the using keyword block
            // also note that here in the constructor we don't specify
            // a value for the optional parameter, but because the default
            // value for it is true, this is the same like we would've been explicit
            // and called new OutWriter("file3.txt", true) instead
            using (OutWriter writer2 = new OutWriter("file3.txt"))
            {
                writer2.Write("line 1");
                writer2.Write("line 2");
            }
        }
    }
}
