using Microsoft.EntityFrameworkCore;
using TodoListWeb.Models;

namespace TodoListWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Todos> Tbl_todos { get; set; }
    }
}
