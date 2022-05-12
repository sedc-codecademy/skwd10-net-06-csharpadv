namespace Class10.Demo1.Helpers
{
    public class OurWriter : IDisposable
    {
        private string _path;

        private StreamWriter _writer;

        private bool disposedValue = false;

        public OurWriter(string filePath)
        {
            _path = filePath;
            _writer = new StreamWriter(_path, true);
        }

        public void Write(string text)
        {
            _writer.WriteLine(text);
        }

        private void _dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _writer.Dispose();
                }
            }

            _path = "";
            disposedValue = true;
        }

        public void Dispose()
        {
            Console.WriteLine("OurWriter Dispose Called");
            _dispose(true);
        }
    }

    public class OurReader : IDisposable
    {
        private string _path;

        private StreamReader _reader;

        private bool disposedValue = false;

        public OurReader(string filePath)
        {
            _path = filePath;
            _reader = new StreamReader(_path);
        }

        public string Read()
        {
            return _reader.ReadToEnd();
        }

        private void _dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Console.WriteLine("Dispose Executed");
                    _reader.Dispose();
                }
            }

            _path = "";
            disposedValue = true;
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose called.");
            _dispose(true);
        }
    }
}
