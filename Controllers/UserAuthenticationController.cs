using ArcticBook.Models.DTO;
using ArcticBook.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace ArcticBook.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }
        public async Task<IActionResult> Register()
        {
            var model = new Registration
            {
                Email = "admin@gmail.com",
                Username = "admin",
                Password = "", //set your password here
                PasswordConfirm = "", //set your password here
                Role = "Admin"
            };

            var result = await authService.RegisterAsync(model);
            return Ok(result.Message);
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if(!ModelState.IsValid)
            
                return View(model);

            
            var result = await authService.LoginAsync(model);
            if(result.StatusCode == 1)
            
                return RedirectToAction("Index", "Home");

            
            else
            {
                TempData["msg"]="Error on server side";
                return RedirectToAction(nameof(Login));
            }
        }
    }
}
