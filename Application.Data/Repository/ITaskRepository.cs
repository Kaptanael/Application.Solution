using Applicationa.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Applicationa.Data.Repository
{
    public interface ITaskRepository : IRepository<UserTask>
    {
        Task<IEnumerable<UserTask>> GetAllTaskWithUser();

        Task<UserTask> GetTaskWithUser(int id);

        Task<IEnumerable<UserTask>> GetAllTaskWithUser(int id);

        Task<List<UserTask>> GetAllTaskByUserId(int id);

        Task<bool> IsExistTaskName(string name);

        Task<bool> IsExistTaskName(string oldName, string name);
    }
}
