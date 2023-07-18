using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum StatusCode
    {
        OK = 200,
        TaskNotFound = 2,
        TaskIsHasAlready = 1,
        InternalServerError = 500
    }
}
