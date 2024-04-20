using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistAppointmentProject.Application.Dtos.Common
{
    public class BaseResponseModel<T> where T : class
    {
        public bool Result { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> ErrorList { get; set; }
    }

}
