using TodoListWeb.Models;

namespace TodoListWeb.Interfaces
{
    public interface IUnitOfWork
    {
        IJobRepository Job { get; }
        public Task Save();
    }
}