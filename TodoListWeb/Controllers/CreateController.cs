using Microsoft.AspNetCore.Mvc;
using TodoListWeb.Data;
using TodoListWeb.Models;

namespace TodoListWeb.Controllers
{
    public class CreateController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CreateController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Todos todos)
        {
            if (!ModelState.IsValid)
            {
                return View(todos);
            }
            _db.tbl_todos.Add(todos);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
