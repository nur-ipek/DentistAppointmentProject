using DentistAppointmentProject.Application.Dtos.Request.Account.Register;
using DentistAppointmentProject.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DentistAppointmentProject.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            RegisterRequestModel registerRequestModel = new RegisterRequestModel()
            {
                Username = "Nipeeek",
                Email = "nur.ipek.tiryaki@gmail.com",
                Password = "PAsWoRd.34"
            };
            await _accountService.RegisterUser(registerRequestModel);
          
            return View();
        }
        //[HttpPost]
        //public IActionResult (LoginViewModel model)
        //{
        //    // Kullanıcı kimlik doğrulamasını işle
        //    if (ModelState.IsValid)
        //    {
        //        // Kullanıcıyı yetkilendir ve giriş yap
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View(model);
        //}
    }
}
