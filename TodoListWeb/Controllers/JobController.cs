using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListWeb.Data;
using TodoListWeb.Models;

namespace TodoListWeb.Controllers
{
    public class JobController : Controller
    {

        private readonly ApplicationDbContext _db;

        public JobController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var jobs = _db.Tbl_todos.OrderBy(x => x.Id).ToList();
            return View(jobs);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Route("Update")]
        public IActionResult Update(Int64 Id)
        {
            var job = _db.Tbl_todos.Find(Id);
            return View(job);
        }

        [HttpPost]
        [Route("CreateJob")]
        public IActionResult CreateJob(Todos todo)
        {
            if (ModelState.IsValid)
            {
                _db.Tbl_todos.Add(todo);
                _db.SaveChanges();
                return RedirectToAction("Index", "Job");
            }
            return RedirectToAction("Create", "Job", todo);
        }

        [HttpPost]
        [Route("UpdateJob")]
        public IActionResult UpdateJob(Todos todo)
        {
            if (ModelState.IsValid)
            {
                _db.Tbl_todos.Update(todo);
                _db.SaveChanges();
                return RedirectToAction("Index", "Job");
            }
            return RedirectToAction("Update", "Job", todo);

        }

        [HttpPost]
        [Route("DeleteJob")]
        public IActionResult DeleteJob(Int64 Id)

        {
            var job = _db.Tbl_todos.Find(Id);
            if (job == null)
            {
                return NotFound();
            }
            _db.Tbl_todos.Remove(job);
            _db.SaveChanges();
            return RedirectToAction("Index", "Job");
        }
    }
}
