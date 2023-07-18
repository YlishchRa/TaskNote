using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Task
{
    public class TaskViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string isDone { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public string Created { get; set; }
    }
}
