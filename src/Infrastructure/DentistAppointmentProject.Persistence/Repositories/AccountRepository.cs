using DentistAppointmentProject.Application.Dtos.Common;
using DentistAppointmentProject.Application.Dtos.Request.Account.Register;
using DentistAppointmentProject.Application.Interfaces.Repositories;
using DentistAppointmentProject.Domain.Entities.Authentication;
using DentistAppointmentProject.Persistence.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DentistAppointmentProject.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public AccountRepository(AppDbContext dbContext, UserManager<User> userManager, RoleManager<Role> roleManager) : base(dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public async Task<BaseResponseModel<NoContent>> RegisterUser(RegisterRequestModel model)
        {

            BaseResponseModel<NoContent> responseModel = new BaseResponseModel<NoContent>();
            try
            {

                //RoleManager
                bool patientRole = _roleManager.Roles.Where(x => x.Name == "Patient").Any();
                IdentityResult roleResult = new IdentityResult();
                if (!patientRole)
                {
                    roleResult = await _roleManager.CreateAsync(new Role
                    {
                        Name = "Patient"
                    });
                }


                //UserManager
                var user = new User { UserName = model.Username, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password); //kayıt işlemi gerçekleştiriliyor.

                if (result.Succeeded) //başarılı ise kullanıcıya yönlendirme yapılacak.
                {
                    await _userManager.AddToRoleAsync(user, "Patient");
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    responseModel.Result = true;
                    responseModel.Message = "Kullanıcı kaydı başarılı";

                }
                else
                {
                    responseModel.ErrorList = result.Errors.Select(t => t.Description).ToList();
                    responseModel.Result = false;
                    responseModel.Message = "Hata ile karşılaşıldı.";
                }


            }
            catch (Exception ex)
            {
                responseModel.ErrorList = new List<string> { ex.Message };
                responseModel.Result = false;
                responseModel.Message = "Hata ile karşılaşıldı.";
               
            }


            return responseModel;
        }
    }
}
