using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AccountController:Controller
    {
        private UserManager<IdentityUser> UserManager;
        private SignInManager<IdentityUser> SignInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl) => View(new LoginModel
        {
            ReturnUrl = returnUrl
        });

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await UserManager.FindByNameAsync(loginModel.Name);
                if (user!=null)
                {
                    await SignInManager.SignOutAsync();
                    if ((await SignInManager.PasswordSignInAsync(user,
                            loginModel.Password, false, false)).Succeeded)
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                }
            }
            
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await SignInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}