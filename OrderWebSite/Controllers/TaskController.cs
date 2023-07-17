using Domain.ViewModels.Task;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Diagnostics;

namespace OrderWebSite.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel model)
        {
            var responce = await taskService.Create(model);
            if(responce.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return Ok(new {description = responce.Description});
            }

            return BadRequest(new { description = responce.Description });
        }
      
    }
}