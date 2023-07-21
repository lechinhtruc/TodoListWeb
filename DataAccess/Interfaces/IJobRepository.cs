using ClosedXML.Excel;
using TodoListWeb.Models;

namespace TodoListWeb.Interfaces
{
    public interface IJobRepository
    {
        public Task<IEnumerable<TodoModel>> GetAllJobAsync();

        public Task<TodoModel> GetJobByIdAsync(long Id);

        public Task<TodoModel> AddJobAsync(TodoModel Job);

        public Task<TodoModel> UpdateJobAsync(TodoModel job);

        public Task<bool> DeleteJobAsync(long Id);

        public Task<object> IsExpiredJob(long Id);

        public Task<XLWorkbook> ExportToExcel();
    }
}