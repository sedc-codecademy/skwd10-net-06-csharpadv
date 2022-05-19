using Class11.Exercise1.Entities;

namespace Class11.Exercise1.DataAccess
{
    public class CsvSubjectDb
    {
        private string _dbDirectory;
        private string _dbFile;
        private int _idTracker = 0;

        public CsvSubjectDb()
        {
            _dbDirectory = @"..\..\..\CsvDb";
            _dbFile = _dbDirectory + $@"\subjects.csv";

            if (!Directory.Exists(_dbDirectory))
            {
                Directory.CreateDirectory(_dbDirectory);
            }
            if (!File.Exists(_dbFile))
            {
                File.Create(_dbFile).Close();
            }

            List<Subject> data = Read();
            if (data == null)
            {
                Write(new List<Subject>());
            }
            else if (data.Count > 0)
            {
                _idTracker = data.Max(x => x.Id);
            }
        }

        private List<Subject> Read()
        {
            try
            {
                List<Subject> data = new List<Subject>();
                using (StreamReader sr = new StreamReader(_dbFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string dbData = sr.ReadLine();
                        string[] objectProperties = dbData.Split(',');
                        Subject subject = new Subject() 
                        { 
                            Id = int.Parse(objectProperties[0]),
                            Title = objectProperties[1],
                            Academy = (Academy)Enum.Parse(typeof(Academy), objectProperties[2], true),
                            Classes = int.Parse(objectProperties[3]),
                        };
                        data.Add(subject);
                    }
                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private bool Write(List<Subject> entities)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_dbFile))
                {
                    string data = string.Empty;
                    foreach(Subject entity in entities)
                    {
                        sw.WriteLine($"{entity.Id},{entity.Title},{entity.Academy},{entity.Classes}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public List<Subject> GetAll()
        {
            return Read();
        }

        public int Insert(Subject entity)
        {
            List<Subject> data = Read();
            _idTracker++;
            entity.Id = _idTracker;
            data.Add(entity);
            Write(data);

            return entity.Id;
        }

        public Subject? GetById(int id)
        {
            List<Subject> data = Read();
            return data.FirstOrDefault(x => x.Id == id);
        }

        public void ClearDb()
        {
            Write(new List<Subject>());
        }
    }
}
