namespace Class14_Workshop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Domain;
    using Newtonsoft.Json;

    public class FileSystemGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private string _tableFilePath = $"table_{typeof(T).Name}.txt";

        public FileSystemGenericRepository()
        {
            if (!File.Exists(_tableFilePath))
            {
                File.Create(_tableFilePath).Close();
            }
        }

        public List<T> GetAll()
        {
            var entityData = GetCurrentTableData();

            return entityData;
        }

        public List<T> Filter(Func<T, bool> filter)
        {
            var entityData = GetCurrentTableData();

            return entityData.Where(filter).ToList();
        }

        public T FindById(int id)
        {
            var entityData = GetCurrentTableData();

            return entityData.SingleOrDefault(entity => entity.Id == id);
        }

        public T Find(Func<T, bool> filter)
        {
            var entityData = GetCurrentTableData();

            return entityData.FirstOrDefault(filter);
        }

        public bool Exists(Func<T, bool> filter)
        {
            var entityData = GetCurrentTableData();

            return entityData.Any(filter);
        }

        public void Insert(T entity)
        {
            var entityData = GetCurrentTableData();

            entityData.Add(entity);

            UpdateTableData(entityData);
        }

        public void InsertMany(List<T> entities)
        {
            var entityData = GetCurrentTableData();

            entityData.AddRange(entities);

            UpdateTableData(entityData);
        }

        public void Update(T entity)
        {
            var entityData = GetCurrentTableData();

            for (int i = 0; i < entityData.Count; i++)
            {
                if (entity.Id == entityData[i].Id)
                {
                    entityData[i] = entity;
                    break;
                }
            }

            UpdateTableData(entityData);
        }

        public void Delete(int id)
        {
            var entityData = GetCurrentTableData();

            T entityToBeDeleted = FindById(id);

            if (entityToBeDeleted != null)
            {
                entityData.Remove(entityToBeDeleted);
            }

            UpdateTableData(entityData);
        }

        private List<T> GetCurrentTableData()
        {
            var currentSerializedData = File.ReadAllText(_tableFilePath);
            var currentEntityData = JsonConvert.DeserializeObject<List<T>>(currentSerializedData);
            return currentEntityData ?? new List<T>();
        }

        private void UpdateTableData(List<T> updatedEntityData)
        {
            var updatedSerializedData = JsonConvert.SerializeObject(updatedEntityData, new JsonSerializerSettings{ReferenceLoopHandling = ReferenceLoopHandling.Serialize});
            File.WriteAllText(_tableFilePath, updatedSerializedData);
        }
    }
}
