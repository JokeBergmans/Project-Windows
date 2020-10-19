using System.Collections.Generic;
using TravelList_API.Models.Domain;

namespace TravelList_API.Models
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
        Task GetBy(int id);
        void Add(Task task);
        void Update(Task task);
        void Delete(Task task);
        void SaveChanges();
    }
}
