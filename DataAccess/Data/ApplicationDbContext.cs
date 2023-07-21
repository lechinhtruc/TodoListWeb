using Microsoft.EntityFrameworkCore;
using TodoListWeb.Models;

namespace TodoListWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TodoModel> Tbl_todos { get; set; }
    }
}
