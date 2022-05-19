using Newtonsoft.Json;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public abstract class FileDatabase<T> : IFileDatabase<T> where T : BaseEntity
    {
        protected List<T> Items;

        private const string DATABASE_FOLDER_NAME = "Database";
        private const string DATABASE_FILE_EXTENSION = ".json";

        private readonly string _databaseFilePath = $"{DATABASE_FOLDER_NAME}\\{typeof(T).Name}{DATABASE_FILE_EXTENSION}";

        public FileDatabase()
        {
            Items = new List<T>();

            if (!Directory.Exists(DATABASE_FOLDER_NAME))
            {
                Directory.CreateDirectory(DATABASE_FOLDER_NAME);
            }

            if (!File.Exists(_databaseFilePath))
            {
                var file = File.Create(_databaseFilePath);
                file.Close();
            }

            Task.Run(async () => Items = await ReadFromFileAsync()).Wait();
        }

        public List<T> GetAll()
        {
            return Items;
        }

        public T GetById(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public async Task InsertAsync(T item)
        {
            T itemToInsert = AutoIncrementId(item);

            Items.Add(itemToInsert);

            await WriteToFileAsync();
        }

        public async Task RemoveAsync(T item)
        {
            Items = Items.Where(x => x.Id != item.Id).ToList();

            await WriteToFileAsync();
        }

        public async Task UpdateAsync(T item)
        {
            await WriteToFileAsync();
        }

        protected T AutoIncrementId(T item)
        {
            int currentId = 0;

            if (Items.Count > 0)
            {
                currentId = Items.OrderByDescending(x => x.Id).First().Id;
            }

            item.Id = ++currentId;

            return item;
        }

        private async Task<List<T>> ReadFromFileAsync()
        {
            using (StreamReader streamReader = new StreamReader(_databaseFilePath))
            {
                string data = await streamReader.ReadToEndAsync();

                List<T> items = JsonConvert.DeserializeObject<List<T>>(data);
                return items ?? new List<T>();
            }
        }
        private async Task WriteToFileAsync()
        {
            using (StreamWriter streamWriter = new StreamWriter(_databaseFilePath))
            {
                string data = JsonConvert.SerializeObject(Items, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                await streamWriter.WriteLineAsync(data);
            }
        }
    }
}
