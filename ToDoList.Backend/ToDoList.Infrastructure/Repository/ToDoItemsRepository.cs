using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Application.Repository;
using ToDoList.Application.Repository.Entity;
using ToDoList.Infrastructure.Database;

namespace ToDoList.Infrastructure.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDBContext _context;

        public ToDoRepository(ToDoDBContext context)
        {
            _context = context;
        }

        public Task<List<ToDoItemEntity>> GetAllToDoItems()
        {
            return _context.ToDoItems.ToListAsync();
        }

        public async Task<bool> AddOrUpdateToDoItem(ToDoItemEntity entity)
        {
            var entityToUpdate = _context.ToDoItems
                .Where(item => item.UID == entity.UID)
                .FirstOrDefault();

            if (entityToUpdate == null)
            {
                _context.ToDoItems.Add(entity);
                var result = await _context.SaveChangesAsync();
                return result == 1;
            }

            entityToUpdate.Description = entity.Description;
            entityToUpdate.Status = entity.Status;

            _context.ToDoItems.Update(entityToUpdate);
            var updateResult = await _context.SaveChangesAsync();
            return updateResult == 1;
        }
    }
}
