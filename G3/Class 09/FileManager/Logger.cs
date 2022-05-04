namespace FileManager
{
    internal class Logger
    {
        internal static void Log(int first, int second, Operation op, int result)
        {
            var message = $"{DateTime.Now.ToLongTimeString()}: {first} {op} {second} = {result}";
            File.AppendAllLines("log.txt", new string[] { message });
        }
    }
}