﻿using Domain.ViewModels.Task;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

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

        public async Task<IActionResult> TaskHandler()
        {
            var responce = await taskService.GetTasks();

            return Json(new {data = responce.Data});
        }

        [HttpPost]
        public async Task<IActionResult> EndTask(long id)
        {
            var responce = await taskService.EndTask(id);
            if (responce.StatusCode == Domain.Enums.StatusCode.OK)
            {
                return Ok(new { description = responce.Description });
            }

            return BadRequest(new { description = responce.Description });
        }

    }
}