using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoListWeb.Data;
using TodoListWeb.Models;

namespace TodoListWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Todos> todoList = _db.tbl_todos.ToList().OrderBy(x => x.Id);
            return View(todoList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}