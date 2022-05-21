using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solids
{
    internal interface IStream<T>
    {
        T Read();
        void Write(T value);
    }

    class HardDiscStreamer : IStream<int>
    {
        public int Read()
        {
            return 0;
        }

        public void Write(int value)
        {
        }
    }

    class DVDStreamer : IStream<string>
    {
        public string Read()
        {
            return string.Empty;
        }

        public void Write(string value)
        {
            throw new NotSupportedException();
        }
    }

    class Factory
    {
        void WriteToStream<T>(IStream<T> stream, T value)
        {
            stream.Write(value);
        }
    }
}
