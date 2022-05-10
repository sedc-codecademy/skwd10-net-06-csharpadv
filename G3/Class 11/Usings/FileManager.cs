using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usings
{
    internal class FileManager: IDisposable
    {

        public string Filename {get; init;}

        private FileStream fileStream;
        private bool disposedValue;
        //private byte[] data = new byte[1_000_000_000];

        public FileManager(string filename)
        {
            Filename = filename;
            fileStream = File.OpenWrite(Filename);
        }

        public void WriteLine(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message+Environment.NewLine);
            fileStream.Write(bytes, 0, bytes.Length);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    fileStream.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                // data = null;
                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~FileManager()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        //public void Dispose()
        //{
        //    fileStream.Dispose();
        //}
    }
}
