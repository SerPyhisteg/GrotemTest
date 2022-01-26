using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Core.Interfaces.Database;
using ToDoList.Core.Models.ToDoItem;
using ToDoList.Database.Entities;

namespace ToDoList.Database.Storage
{
    public partial class DatabaseStorage : IToDoItemStorage
    {
        public IEnumerable<ToDoItemModel> GetAllItems()
        {
            IEnumerable<ToDoItemEntity> entities;

            using (var connection = Connection)
            {
                entities = connection.Table<ToDoItemEntity>();
            }

            entities = entities.OrderBy(entity => entity.Id);

            return ToModel(entities);
        }

        public ToDoItemModel GetItem(Guid uid)
        {
            ToDoItemEntity entity;

            using (var connection = Connection)
            {
                entity = connection.Find<ToDoItemEntity>(item => item.UID == uid);
            }

            return ToModel(entity);
        }

        public void SaveAllItems(IEnumerable<ToDoItemModel> items)
        {
            var entities = ToModel(items);

            using (var connection = Connection)
            {
                connection.InsertAll(entities);
            }
        }

        public void UpdateItem(ToDoItemModel item)
        {
            var entity = ToModel(item);

            using (var connection = Connection)
            {
                var entityToUpdate = connection.Find<ToDoItemEntity>(ent => ent.UID == item.UID);
                if (entityToUpdate != null)
                {
                    entityToUpdate.Status = entity.Status;
                    entityToUpdate.Description = entity.Description;
                    connection.Update(entityToUpdate);
                }
                else
                {
                    connection.Insert(entity);
                }
                
            }
        }

        public void SaveItem(ToDoItemModel item)
        {
            var entity = ToModel(item);

            using (var connection = Connection)
            {
                connection.Insert(entity);
            }
        }

        private IEnumerable<ToDoItemModel> ToModel(IEnumerable<ToDoItemEntity> entities)
        {
            return Mapper.Map<IEnumerable<ToDoItemModel>>(entities);
        }

        private IEnumerable<ToDoItemEntity> ToModel(IEnumerable<ToDoItemModel> items)
        {
            return Mapper.Map<IEnumerable<ToDoItemEntity>>(items);
        }

        private ToDoItemEntity ToModel(ToDoItemModel item)
        {
            return Mapper.Map<ToDoItemEntity>(item);
        }

        private ToDoItemModel ToModel(ToDoItemEntity item)
        {
            return Mapper.Map<ToDoItemModel>(item);
        }
    }
}
