using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeDeserialize.Services
{
    public class FileSystemService
    {
        public string ReadFileContent(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception($"The file {path} was not found!");
            }

            string result = string.Empty;
            using(StreamReader streamReader = new StreamReader(path))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public void WriteInFile(string path, string content)
        {
            using(StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(content);
            }
        }
    }
}
