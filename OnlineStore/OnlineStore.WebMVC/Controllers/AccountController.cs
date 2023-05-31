using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using OnlineStore.Application.Users.Commands.CreateUser;
using OnlineStore.Application.Users.DTO;
using OnlineStore.Application.Users.Queries.LoginUser;

namespace OnlineStore.WebMVC.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserCommand model)
        {
            if (ModelState.IsValid)
            {
                var user = await Mediator.Send(model);

                await Authenticate(user);

                return RedirectToAction("Index", "Home");

            }
            else
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            return View(model);

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserQuery model)
        {
            if (ModelState.IsValid)
            {
                var user = await Mediator.Send(model);
                if (user != null && user.IsAccess != false)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(UserDto user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleName),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.FirstName),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
