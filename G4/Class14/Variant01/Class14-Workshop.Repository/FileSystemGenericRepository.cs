namespace Class14_Workshop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Domain;
    using Newtonsoft.Json;

    /// <summary>
    /// File-based generic repository, creating separate table file for each type of entity.
    /// </summary>
    /// <typeparam name="T">Type of entities in the repository.</typeparam>
    public class FileSystemGenericRepository<T> : IGenericRepository<T>, IEntityIdProvider where T : BaseEntity
    {
        private string _filePath = $"db_table_{typeof(T).Name}.txt";

        public FileSystemGenericRepository()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }

        public List<T> GetAll()
        {
            List<T> deserializedData = GetTableData();

            return deserializedData;
        }

        public List<T> Filter(Func<T, bool> filter)
        {
            List<T> deserializedData = GetTableData();

            return deserializedData.Where(filter).ToList();
        }

        public T FindById(int id)
        {
            List<T> deserializedData = GetTableData();

            return deserializedData.SingleOrDefault(entity => entity.Id == id);
        }

        public T Find(Func<T, bool> filter)
        {
            List<T> deserializedData = GetTableData();

            return deserializedData.FirstOrDefault(filter);
        }

        public bool Exists(Func<T, bool> filter)
        {
            List<T> deserializedData = GetTableData();

            return deserializedData.Any(filter);
        }

        public void Insert(T entity)
        {
            List<T> deserializedData = GetTableData();

            if (entity.Id == 0)
            {
                entity.Id = GetNextId();
            }

            if (!Exists(existingEntity => existingEntity.Id == entity.Id))
            {
                deserializedData.Add(entity);
                UpdateTableData(deserializedData);
            }
        }

        public void InsertMany(List<T> entities)
        {
            List<T> deserializedData = GetTableData();

            if (deserializedData.Count == 0)
            {
                foreach (var entity in entities)
                {
                    if (entity.Id == 0)
                    {
                        entity.Id = GetNextId();
                    }
                }

                deserializedData.AddRange(entities);
            }
            else
            {
                for (var i = 0; i < entities.Count; i++)
                {
                    var entity = entities[i];

                    if (entity.Id == 0)
                    {
                        entity.Id = GetNextId();
                    }

                    if (!Exists(existingEntity => existingEntity.Id == entity.Id))
                    {
                        deserializedData.Add(entity);
                    }
                }
            }

            UpdateTableData(deserializedData);
        }

        public void Update(T entity)
        {
            List<T> deserializedData = GetTableData();

            for (int i = 0; i < deserializedData.Count; i++)
            {
                if (deserializedData[i].Id == entity.Id)
                {
                    deserializedData[i] = entity;
                    break;
                }
            }

            UpdateTableData(deserializedData);
        }

        public void Delete(int id)
        {
            List<T> deserializedData = GetTableData();

            T entityToBeDeleted = deserializedData.SingleOrDefault(entity => entity.Id == id);

            if (entityToBeDeleted != null)
            {
                deserializedData.Remove(entityToBeDeleted);
            }

            UpdateTableData(deserializedData);
        }

        public int GetNextId()
        {
            List<T> deserializedData = GetTableData();

            if (!deserializedData.Any())
            {
                return 1;
            }

            int currentLatestId = deserializedData.Max(entity => entity.Id);

            return ++currentLatestId;
        }

        /// <summary>
        /// Helper method for reading current state of table data from file.
        /// </summary>
        /// <returns>Current list of entities in table file.</returns>
        private List<T> GetTableData()
        {
            string serializedData = File.ReadAllText(_filePath);
            List<T> deserializedData = JsonConvert.DeserializeObject<List<T>>(serializedData,
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            if (deserializedData == null)
            {
                deserializedData = new List<T>();
            }

            return deserializedData;
        }

        /// <summary>
        /// Helper method for updating current state of table data to file.
        /// </summary>
        private void UpdateTableData(List<T> deserializedData)
        {
            string serializedData = JsonConvert.SerializeObject(deserializedData, Formatting.Indented,
                new JsonSerializerSettings {PreserveReferencesHandling = PreserveReferencesHandling.Objects});
            File.WriteAllText(_filePath, serializedData);
        }
    }
}
