using TodoListWeb.Data;
using TodoListWeb.Interfaces;

namespace TodoListWeb.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IJobRepository Job { get; }

        public UnitOfWork(ApplicationDbContext db, IJobRepository jobRepository)
        {
            _db = db;
            Job = jobRepository;
        }
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}