using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disposing.InputOutputHelper
{
    public class OurReader : IDisposable
    {
        private StreamReader _streamReader;
        private bool _disposedValue;

        public OurReader(string path)
        {
            _streamReader = new StreamReader(path);
            _disposedValue = false;
        }

        public string Read()
        {
            return _streamReader.ReadToEnd();
        }

        public void Dispose()
        {
            if (!_disposedValue)
            {
                _streamReader?.Dispose();
                _disposedValue = true;
            }
        }
    }
}
