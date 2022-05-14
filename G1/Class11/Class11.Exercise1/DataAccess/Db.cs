using Class11.Exercise1.Entities;
using Newtonsoft.Json;

namespace Class11.Exercise1.DataAccess
{
    public class Db<T> where T : BaseEntity
    {
        private string _dbDirectory;
        private string _dbFile;
        private int _idTracker = 0;

        public Db()
        {
            _dbDirectory = "Db";
            _dbFile = _dbDirectory + $@"\{typeof(T).Name}s.json";

            if(!Directory.Exists(_dbDirectory))
            {
                Directory.CreateDirectory(_dbDirectory);
            }
            if(!File.Exists(_dbFile))
            {
                File.Create(_dbFile).Close();
            }

            List<T> data = Read();
            if(data == null)
            {
                Write(new List<T>());
            }
            else if(data.Count > 0)
            {
                _idTracker = data.Max(x => x.Id);
            }
        }

        private List<T> Read()
        {
            try
            {
                using(StreamReader sr = new StreamReader(_dbFile))
                {
                    string dbData = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<T>>(dbData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private bool Write(List<T> entities)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(_dbFile))
                {
                    string data = JsonConvert.SerializeObject(entities);
                    sw.WriteLine(data);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public List<T> GetAll()
        {
            return Read();
        }

        public int Insert(T entity)
        {
            List<T> data = Read();
            _idTracker++;
            entity.Id = _idTracker;
            data.Add(entity);
            Write(data);

            return entity.Id;
        }

        public T? GetById(int id)
        {
            List<T> data = Read();
            return data.FirstOrDefault(x => x.Id == id);
        }

        public void ClearDb()
        {
            Write(new List<T>());
        }
    }
}
