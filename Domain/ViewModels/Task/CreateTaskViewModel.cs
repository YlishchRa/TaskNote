﻿using Domain.Enums;
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

    }
}
