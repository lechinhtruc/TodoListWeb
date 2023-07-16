using Microsoft.EntityFrameworkCore;
using TodoListWeb.Models;

namespace TodoListWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Todos> tbl_todos { get; set; }
    }
}
