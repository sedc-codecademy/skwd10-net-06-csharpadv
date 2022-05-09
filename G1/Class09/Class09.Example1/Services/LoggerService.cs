namespace Class09.Example1.Services
{
    public class LoggerService
    {
        private string _directoryPath = "../../../logs";
        private string _logFilePath = "../../../logs/log.txt";
        private string _errorCounterPath = "../../../logs/errorCounter.txt";

        public LoggerService()
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
        }

        public void Log(string error, string message, string username)
        {
            using(StreamWriter sw = new StreamWriter(_logFilePath, true))
            {
                sw.WriteLine($"Error: {error}");
                sw.WriteLine($"Message: {message}");
                sw.WriteLine($"Date and time: {DateTime.UtcNow}");
                sw.WriteLine($"Username: {username}");
                sw.WriteLine("=========================================================");
            }
        }

        public void LogError()
        {
            int count = 0;
            if (!File.Exists(_errorCounterPath))
            {
                File.Create(_errorCounterPath).Close();
            }

            using (StreamReader sr = new StreamReader(_errorCounterPath))
            {
                bool isNumber = int.TryParse(sr.ReadLine(), out count);
            }

            using (StreamWriter sw = new StreamWriter(_errorCounterPath))
            {
                sw.WriteLine(count + 1);
            }
        }
    }
}
