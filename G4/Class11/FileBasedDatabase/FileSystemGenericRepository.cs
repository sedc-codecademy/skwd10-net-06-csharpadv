namespace FileBasedDatabase
{
    using System.Collections.Generic;
    using System.IO;
    using Models;
    using Newtonsoft.Json;

    class FileSystemGenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        /// <summary>
        /// File path that will be used to write all the entities of the specified
        /// <see cref="T"/> type as we invoke the generic repository methods.
        /// Having separate repository for each entity points to having a unique
        /// path for each entity, hence the typeof(T).Name addition to the path
        /// (it will change the file name depending on the entity type name).
        /// </summary>
        private string _filePath = $"db_{typeof(T).Name}.txt";

        public FileSystemGenericRepository()
        {
            EnsureDbFileExists();
        }

        public List<T> GetAll()
        {
            // read current state
            string currentData = File.ReadAllText(_filePath);

            // deserialize to list
            List<T> entities = JsonConvert.DeserializeObject<List<T>>(currentData);

            // return list
            return entities;
        }

        public void Insert(T entity)
        {
            // read current state
            string currentData = File.ReadAllText(_filePath);

            // deserialize data
            List<T> currentEntities = JsonConvert.DeserializeObject<List<T>>(currentData);

            // in cases where the file is empty, deserialized value will be null
            // initialize the list in that case
            if (currentEntities == null)
            {
                currentEntities = new List<T>();
            }

            // add entity to deserialized list
            currentEntities.Add(entity);

            // re-serialize list
            string serializedEntities = JsonConvert.SerializeObject(currentEntities);

            // write it to same file, overwriting previous contents
            // because we are reserializing the whole list
            File.WriteAllText(_filePath, serializedEntities);
        }

        /// <summary>
        /// Helper method to ensure that the file we will be writing to exists before
        /// attempting to do so.
        /// </summary>
        private void EnsureDbFileExists()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }
    }
}
