using DentistAppointmentProject.Application.Dtos.Common;
using DentistAppointmentProject.Application.Dtos.Request.Account.Register;
using DentistAppointmentProject.Application.Interfaces.Repositories;
using DentistAppointmentProject.Application.Interfaces.Services;
using DentistAppointmentProject.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistAppointmentProject.Persistence.Services
{
    public class AccountService : IAccountService
    {
        //DI
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<BaseResponseModel<NoContent>> RegisterUser(RegisterRequestModel model)
        {
            //TC, email kontrolleri burada.  
            return await _accountRepository.RegisterUser(model);
        }
    }
}
