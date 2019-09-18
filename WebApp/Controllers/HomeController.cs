using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceBusMessaging.Interfaces;
using ServiceBusMessaging.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IServiceBusTopicSender _serviceBusTopicSender;

        public HomeController(SignInManager<IdentityUser> signInManager, IServiceBusTopicSender serviceBusTopicSender)
        {
            _signInManager = signInManager;
            _serviceBusTopicSender = serviceBusTopicSender;
        }

        public async Task<IActionResult> Auth(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                //_logger.LogInformation("User logged in.");
                //return LocalRedirect(returnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                //return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
            }
            if (result.IsLockedOut)
            {
                //_logger.LogWarning("User account locked out.");
                //return RedirectToPage("./Lockout");
            }
            else
            {
                //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //return Page();
            }

            return Ok("Dina");
        }

        [Authorize]
        public async Task<IActionResult> Test()
        {
            await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "Test"  });
            return Ok("Dina");
        }
    }
}
