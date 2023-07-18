using Domain.Entity;
using Domain.ViewModels.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        const string path = @"../Database/data.xml";
        public List<TaskEntity> tasks { get; set; }
        Task Create(T entity);

        Task Delete(T entity);
        
        Task<T> Update(T entity);
        List<TaskEntity> GetAll();

        Task<T> Find(CreateTaskViewModel entity);

        void SaveTasks();
    }
}
