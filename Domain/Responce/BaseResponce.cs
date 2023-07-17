using Domain.Enums;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Responce
{
    public class BaseResponce<T> : IBaseResponce<T>
    {
       
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }

    public interface IBaseResponce<T>
    {
        string Description { get; }
        StatusCode StatusCode { get;  }

        T Data { get; }
    }

}
