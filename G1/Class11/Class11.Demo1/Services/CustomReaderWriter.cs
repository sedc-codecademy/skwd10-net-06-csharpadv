namespace Class11.Demo1.Services
{
    public class CustomReaderWriter
    {
        public bool WriteFile(string filePath, string json)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(json);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string ReadFile(string filePath)
        {
            string json = string.Empty;

            if (!File.Exists(filePath))
            {
                return json;
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                json = sr.ReadToEnd();
            }

            return json;
        }
    }
}
