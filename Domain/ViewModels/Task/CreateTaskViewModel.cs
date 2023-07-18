using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Task
{
    public class CreateTaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }


        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException(Name, "Enter name of task");
            }
            if (string.IsNullOrEmpty(Description))
            {
                throw new ArgumentNullException(Name, "Enter Description of task");
            }
        }
    }
}
