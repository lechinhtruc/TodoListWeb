using Microsoft.AspNetCore.Mvc;
using TodoListWeb.Data;
using TodoListWeb.Models;

namespace TodoListWeb.Controllers
{
    public class UpdateController : Controller
    {

        private readonly ApplicationDbContext _db;

        public UpdateController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("UpdateJob")]
        public IActionResult Index(Int64 id)
        {
            var todo = _db.Tbl_todos.Find(id);
            return View(todo);
        }

        //Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Todos todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }
            _db.Tbl_todos.Update(todo);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
