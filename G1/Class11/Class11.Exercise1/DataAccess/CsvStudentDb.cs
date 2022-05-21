using Class11.Exercise1.Entities;

namespace Class11.Exercise1.DataAccess
{
    public class CsvStudentDb
    {
        private string _dbDirectory;
        private string _dbFile;
        private int _idTracker = 0;

        public CsvStudentDb()
        {
            _dbDirectory = @"..\..\..\CsvDb";
            _dbFile = _dbDirectory + $@"\students.csv";

            if (!Directory.Exists(_dbDirectory))
            {
                Directory.CreateDirectory(_dbDirectory);
            }
            if (!File.Exists(_dbFile))
            {
                File.Create(_dbFile).Close();
            }

            List<Student> data = Read();
            if (data == null)
            {
                Write(new List<Student>());
            }
            else if (data.Count > 0)
            {
                _idTracker = data.Max(x => x.Id);
            }
        }

        private List<Student> Read()
        {
            try
            {
                List<Student> data = new List<Student>();
                using (StreamReader sr = new StreamReader(_dbFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string dbData = sr.ReadLine();
                        string[] objectProperties = dbData.Split(',');
                        Student student = new Student() 
                        { 
                            Id = int.Parse(objectProperties[0]),
                            FirstName = objectProperties[1],
                            LastName = objectProperties[2],
                            Age = int.Parse(objectProperties[3]),
                        };
                        data.Add(student);
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

        private bool Write(List<Student> entities)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_dbFile))
                {
                    string data = string.Empty;
                    foreach(Student entity in entities)
                    {
                        sw.WriteLine($"{entity.Id},{entity.FirstName},{entity.LastName},{entity.Age}");
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

        public List<Student> GetAll()
        {
            return Read();
        }

        public int Insert(Student entity)
        {
            List<Student> data = Read();
            _idTracker++;
            entity.Id = _idTracker;
            data.Add(entity);
            Write(data);

            return entity.Id;
        }

        public Student? GetById(int id)
        {
            List<Student> data = Read();
            return data.FirstOrDefault(x => x.Id == id);
        }

        public void ClearDb()
        {
            Write(new List<Student>());
        }
    }
}
