using DentistAppointmentProject.Application.Dtos.Request.Account.Register;
using DentistAppointmentProject.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistAppointmentProject.Application.Interfaces.Repositories
{
    public interface IAccountRepository:IGenericRepository<User>
    {
        Task<bool> RegisterUser(RegisterRequestModel model);
    }
}
