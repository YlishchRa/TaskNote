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
        TaskIsHasAlready = 1,
        InternalServerError = 500
    }
}
