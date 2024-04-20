using DentistAppointmentProject.Application.Dtos.Common;
using DentistAppointmentProject.Application.Dtos.Request.Account.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistAppointmentProject.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<BaseResponseModel<NoContent>> RegisterUser(RegisterRequestModel model);
    }
}
