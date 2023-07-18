using DAL.Interfaces;
using Domain.Entity;
using Domain.Enums;
using Domain.Responce;
using Domain.ViewModels.Task;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IBaseRepository<TaskEntity> _taskRepository;
        private ILogger<TaskService> _logger;
        public TaskService(IBaseRepository<TaskEntity> taskRepository, ILogger<TaskService> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<IBaseResponce<TaskEntity>> Create(CreateTaskViewModel model)
        {
            try
            {
                model.Validate();
                _logger.LogInformation($"Request to create the task - {model.Name}");
                var task = await _taskRepository.Find(model);

                if (task != null)
                {
                    return new BaseResponce<TaskEntity>()
                    {
                        Description = "Task with this name has already here",
                        StatusCode = StatusCode.TaskIsHasAlready
                    };
                }

                task = new TaskEntity()
                {
                    Name = model.Name,
                    Description = model.Description,
                    priority = model.Priority,
                    Created = DateTime.Now,
                    isDone = false
                };


                _logger.LogInformation($"Task {model.Name} is already created at {task.Created}");
                await _taskRepository.Create(task);
                return new BaseResponce<TaskEntity>()
                {
                    StatusCode = StatusCode.OK,
                    Description = "Task has successfully created"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponce<TaskEntity>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"{ex.Message}"
                };
            }
        }

        public async Task<IBaseResponce<IEnumerable<TaskViewModel>>> GetTasks()
        {
            try
            {
                var task = _taskRepository.GetAll();

                List< TaskViewModel > tmp = new List< TaskViewModel >();

                for(int i =0; i < task.Count; i++)
                {
                    tmp.Add(new TaskViewModel
                    {
                        Id = task[i].Id,
                        Name = task[i].Name,
                        Description = task[i].Description,
                        Priority = task[i].priority.ToString(),
                        isDone = task[i].isDone.ToString(),
                        Created = task[i].Created.ToString(),
                    });
                }
                return new BaseResponce<IEnumerable<TaskViewModel>>()
                {
                    Data = tmp,
                    StatusCode = StatusCode.OK,
                };

            }
            catch (Exception ex)
            {
                return new BaseResponce<IEnumerable<TaskViewModel>>()
                {
                    Description = $"{ex.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };

            }
        }
    }
}
