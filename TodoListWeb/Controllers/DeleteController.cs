using Microsoft.AspNetCore.Mvc;
using TodoListWeb.Data;
using TodoListWeb.Models;

namespace TodoListWeb.Controllers
{
    public class DeleteController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DeleteController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Index(Todos todo)
        {
            _db.tbl_todos.Remove(todo);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
