using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    [Serializable]
    public enum Priority
    {
        [Display(Name = "LOW")]
        low,
        [Display(Name = "MEDIUM")]
        medium,
        [Display(Name = "HIGH")]
        high
    }

}
