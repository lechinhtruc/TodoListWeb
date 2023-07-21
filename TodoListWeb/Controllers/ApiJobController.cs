using Microsoft.AspNetCore.Mvc;
using TodoListWeb.Interfaces;
using TodoListWeb.Models;

namespace TodoListWeb.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class ApiJobController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ApiJobController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllJob()
        {
            try
            {
                return Ok(await _unitOfWork.Job.GetAllJobAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetJobById(Int64 Id)
        {
            try
            {
                return Ok(await _unitOfWork.Job.GetJobByIdAsync(Id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(TodoModel todo)
        {
            try
            {
                await _unitOfWork.Job.AddJobAsync(todo);
                await _unitOfWork.Save();
                return Ok(new { status = 200, created = todo });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateJob(TodoModel todo)
        {
            try
            {
                await _unitOfWork.Job.UpdateJobAsync(todo);
                await _unitOfWork.Save();
                return Ok(new { status = 200, update = "success" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJob(Int64 Id)
        {
            try
            {
                await _unitOfWork.Job.DeleteJobAsync(Id);
                await _unitOfWork.Save();
                return Ok(new { status = 200, deleted = "success" });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> CheckJobExpired(Int64 jobId)
        {
            try
            {
                return Ok(new { status = 200, data = await _unitOfWork.Job.IsExpiredJob(jobId) });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
