using Domain.Entity;
using Domain.Responce;
using Domain.ViewModels.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITaskService
    {
        Task<IBaseResponce<TaskEntity>> Create(CreateTaskViewModel model);
    }
}
