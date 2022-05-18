using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingObjects
{
    internal static class Utils
    {
        public static Stream GenerateStreamFromString(string source)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(source);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
