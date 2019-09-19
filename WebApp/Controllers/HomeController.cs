using System;
using System.Net;
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

    //  [Authorize]
        public async Task<IActionResult> Test()
        {

            await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "Test"  });
            return Ok("Dina");
        }

        [HttpGet]
        public async Task<ActionResult> Courses()
        {
            try
            {
                await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetCourses" });

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet("courses/{id}")]
        public async Task<ActionResult> GetCourseDetails(int id)
        {
            try
            {

                await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetCourseDetails", JsonContent = id.ToString() });

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Exams()
        {
            try
            {
                await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetExams" });
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet("exams/{id}")]
        public async Task<ActionResult> GetExamDetails(int id)
        {
            try
            {

                await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetExamDetails", JsonContent = id.ToString() });
                return Ok();


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GenerateReport()
        {
            try
            {
                await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GenerateReport" });
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Students()
        {
            try
            {
                await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetStudents" });
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet("students/{id}")]
        public async Task<ActionResult> GetStudentDetails(int id)
        {
            try
            {

                await _serviceBusTopicSender.SendMessage(new Payload() { ActionName = "GetStudentDetails", JsonContent = id.ToString() });
                return Ok();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

    }
}
