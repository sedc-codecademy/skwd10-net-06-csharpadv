namespace Program // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bobSong = "Heey, this is the Bob song. Yea. Bob song. It is really awesome! Extra words, extra words!";

            // extension methods are, literally, fancy static methods
            string shortenedString = StringHelper.Shorten(bobSong, 4);
            string quotedString = StringHelper.QuoteString(shortenedString);

            Console.WriteLine($"static invocation: {quotedString}");

            // they can make methods look like they are a part
            // of the class they are extending. Keep usage to some
            // additional methods that don't necessarily belong in the
            // class itself (aren't tied to modelling the class, but rather
            // helpers or some afterthought methods)
            shortenedString = bobSong.Shorten(4);
            quotedString = shortenedString.QuoteString();

            Console.WriteLine($"extension invocation: {quotedString}");
        }
    }
}