namespace AsyncGenericRepository
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    class FileSystemAsyncGenericRepository<T> : IAsyncGenericRepository<T> where T: BaseEntity
    {
        private string _filePath = $"db_{typeof(T).Name}.txt";

        public FileSystemAsyncGenericRepository()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            string currentContent = await File.ReadAllTextAsync(_filePath);

            List<T> deserializedEntities = JsonConvert.DeserializeObject<List<T>>(currentContent);

            return deserializedEntities;
        }

        public async Task InsertAsync(T entity)
        {
            string currentContent = await File.ReadAllTextAsync(_filePath);

            List<T> deserializedEntities = JsonConvert.DeserializeObject<List<T>>(currentContent);

            if (deserializedEntities == null)
            {
                deserializedEntities = new List<T>();
            }

            deserializedEntities.Add(entity);

            string serializedEntities = JsonConvert.SerializeObject(deserializedEntities);

            await File.WriteAllTextAsync(_filePath, serializedEntities);
        }
    }
}
