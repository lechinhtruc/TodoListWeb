using ClosedXML.Extensions;
using Microsoft.AspNetCore.Mvc;
using TodoListWeb.Interfaces;
using TodoListWeb.Models;

namespace TodoListWeb.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class JobController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Job.GetAllJobAsync());
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Route("Update")]
        public async Task<IActionResult> Update(Int64 Id)
        {
            return View(await _unitOfWork.Job.GetJobByIdAsync(Id));
        }

        public async Task<IActionResult> ExportToExcel()
        {
            var stream = await _unitOfWork.Job.ExportToExcel();
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Export_Todo_List_" + DateTime.Now.ToString());
        }
    }
}
