using DentistAppointmentProject.Application.Dtos.Request.Account.Register;
using DentistAppointmentProject.Application.Interfaces.Repositories;
using DentistAppointmentProject.Domain.Entities.Authentication;
using DentistAppointmentProject.Persistence.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistAppointmentProject.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {
        private readonly UserManager<User> _userManager;
       
        public AccountRepository(AppDbContext dbContext, UserManager<User> userManager) : base(dbContext)
        {
            _userManager= userManager;
             
        }

        public async Task<bool> RegisterUser(RegisterRequestModel model)
        {
            try
            {
                var user = new User { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return false;
        }
    }
}
