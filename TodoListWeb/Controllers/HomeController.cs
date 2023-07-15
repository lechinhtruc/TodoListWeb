using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoListWeb.Data;
using TodoListWeb.Models;

namespace TodoListWeb.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            IEnumerable<TodosModel> todoList = _db.tbl_todos.ToList().OrderBy(x => x.Id);
            return View(todoList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(Int64 id)
        {
            return View(_db.tbl_todos.Find(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodosModel todos)
        {
            if (!ModelState.IsValid)
            {
                return View(todos);
            }
            _db.tbl_todos.Add(todos);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TodosModel todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }
            _db.tbl_todos.Update(todo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(Int64 id)
        {
            _db.tbl_todos.Remove(_db.tbl_todos.Find(id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}