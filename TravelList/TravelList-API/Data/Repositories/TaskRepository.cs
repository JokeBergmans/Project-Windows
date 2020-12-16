using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TravelList_API.Models;
using TravelList_API.Models.Domain;

namespace TravelList_API.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Task> _tasks;
        #endregion

        #region Constructors
        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
            _tasks = context.Tasks;
        }
        #endregion

        #region Methods
        public IEnumerable<Task> GetAll()
        {
            return _tasks.OrderBy(t => t.Completed).ThenBy(t => t.Name).ToList();
        }

        public Task GetBy(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Task task)
        {
            _tasks.Add(task);
        }

        public void Update(Task task)
        {
            _tasks.Update(task);
        }

        public void Delete(Task task)
        {
            _tasks.Remove(task);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
