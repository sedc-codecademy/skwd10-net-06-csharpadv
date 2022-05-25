using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solids
{
    internal interface IReadableStream<T>
    {
        T Read();
    }

    internal interface IWriteableStream<T>
    {
        void Write(T value);
    }

    internal interface IDuplexStream<T> : IReadableStream<T>, IWriteableStream<T> { }   



    class HardDisc2Streamer : IDuplexStream<int>
    {
        public int Read()
        {
            return 0;
        }

        public void Write(int value)
        {
        }
    }

    class DVD2Streamer : IReadableStream<string>
    {
        public string Read()
        {
            return string.Empty;
        }
    }

    class Factory2
    {
        void WriteToStream<T>(IWriteableStream<T> stream, T value)
        {
            stream.Write(value);
        }
    }

    class StreamManager
    {
        private IDuplexStream<int> stream;
        public StreamManager (IDuplexStream<int> inputStream)
        {
            stream = inputStream;
        }

        // ...
    }
}
