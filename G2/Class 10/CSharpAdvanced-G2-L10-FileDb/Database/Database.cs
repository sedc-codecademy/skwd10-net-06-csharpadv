using CSharpAdvanced_G2_L10_FileDb.Entities;
using Newtonsoft.Json;

namespace CSharpAdvanced_G2_L10_FileDb.Database
{
    public abstract class Database<T> where T : BaseEntity
    {
        private readonly List<T> _entities;
        private readonly string _fileLocation;
        private int _currentId = 0;

        public Database()
        {
            _fileLocation =  $@"{Directory.GetCurrentDirectory()}\{typeof(T).Name}.json";

            if (!File.Exists(_fileLocation))
            {
                var stream = File.Create(_fileLocation);
                stream.Close();
            }

            _entities = ReadFromFile();
            _currentId = _entities.OrderBy(x => x.Id).LastOrDefault()?.Id ?? 0;
        }

        public List<T> GetAll()
        {
            return _entities;
        }

        public void Insert(T item)
        {
            AutoIncrementId(item);

            _entities.Add(item);

            WriteToFile();
        }

        public void Update(T item)
        {
            WriteToFile();
        }

        private void AutoIncrementId(T item)
        {
            item.Id = ++_currentId;
        }
        
        private void WriteToFile()
        {
            using (StreamWriter sw = new StreamWriter(_fileLocation))
            {
                string json = JsonConvert.SerializeObject(_entities);
                sw.Write(json);
                sw.Flush();
            }
        }

        private List<T> ReadFromFile()
        {
            List<T> entities = new List<T>();
            using (StreamReader sr = new StreamReader(_fileLocation))
            {
                string json = sr.ReadToEnd();
                entities = JsonConvert.DeserializeObject<List<T>>(json);
            }

            return entities ?? new List<T>();
        }
    }
}
