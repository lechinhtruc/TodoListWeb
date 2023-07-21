using TodoListWeb.Data;
using TodoListWeb.Models;
using Microsoft.EntityFrameworkCore;
using TodoListWeb.Interfaces;
using ClosedXML.Excel;
using System.Data;
using System.Reflection;

namespace TodoListWeb.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _db;
        public JobRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TodoModel> AddJobAsync(TodoModel job)
        {
            TodoModel todo = new()
            {
                JobName = job.JobName,
                IsDone = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(5),
            };
            await _db.Tbl_todos.AddAsync(todo);
            return todo;
        }

        public async Task<IEnumerable<TodoModel>> GetAllJobAsync()
        {
            return await _db.Tbl_todos.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<TodoModel> GetJobByIdAsync(long Id)
        {
            var job = await _db.Tbl_todos.FirstOrDefaultAsync(x => x.Id == Id);
            return job ?? new TodoModel() { JobName = "" };
        }

        public async Task<TodoModel> UpdateJobAsync(TodoModel job)
        {
            var findJob = await _db.Tbl_todos.Where(x => x.Id == job.Id).FirstOrDefaultAsync();
            if (findJob != null)
            {
                findJob.JobName = job.JobName;
                findJob.IsDone = job.IsDone;
                _db.Tbl_todos.Update(findJob);
            }
            return job;
        }

        public async Task<bool> DeleteJobAsync(Int64 Id)
        {
            var deleteJob = await _db.Tbl_todos.FindAsync(Id);
            if (deleteJob != null)
            {
                _db.Tbl_todos.Remove(deleteJob);
                return true;
            }
            return false;
        }

        public async Task<object> IsExpiredJob(Int64 Id)
        {
            var job = await _db.Tbl_todos.SingleOrDefaultAsync(x => x.Id == Id);
            if (job != null)
            {
                if (DateTime.Now < job?.EndDate)
                {
                    return new { expired = false, msg = "" };
                }
                return new { expired = true, msg = $"{job?.JobName} is expired at {job?.EndDate}" };
            }
            return new { };
        }

        public async Task<MemoryStream> ExportToExcel()
        {
            XLWorkbook workbook = new();
            MemoryStream stream = new();
            DataTable table = ListToDataTable(await _db.Tbl_todos.OrderBy(x => x.Id).ToListAsync(), "Todo");

            var worksheet = workbook.AddWorksheet();
            worksheet.FirstCell().InsertTable(table, true);
            workbook.SaveAs(stream);
            return stream;
        }

        public static DataTable ListToDataTable<T>(List<T> list, string _tableName)
        {
            DataTable dt = new(_tableName);

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }
            foreach (T t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    row[info.Name] = info.GetValue(t, null) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }


    }
}