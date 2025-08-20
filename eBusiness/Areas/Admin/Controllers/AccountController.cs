using eBusiness.Areas.Admin.ViewModels;
using eBusiness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserManager { get; }
        public SignInManager<AppUser> SignInManager { get; }

        public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> signInManager)
        {
            UserManager = _userManager;
            SignInManager = signInManager;
        }

        // GET: AccountController/Signup
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        // POST: AccountController/Signup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Signup(Signup collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Enter Email And Password");
                    return View();
                }
                var User = new AppUser
                {
                    Email = collection.Email,
                    UserName = collection.Email,
                    PhoneNumber = collection.PhoneNumber
                };
                var Resault = await UserManager.CreateAsync(User, collection.Password);
                if (Resault.Succeeded)
                {
                    await SignInManager.SignInAsync(User, isPersistent: false);
                    return RedirectToAction("Index", "AppUser");

                }
                else
                {
                    ModelState.AddModelError("", "Wrong Email or Password");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Signin
        public ActionResult Signin(int id)
        {
            return View();
        }

        // POST: AccountController/Signin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Signin(int id, Signin collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Email or Password not correct..!");
                    return View();
                }

                var Resualt = await SignInManager.PasswordSignInAsync(collection.Email, collection.Password, collection.RememberMe, false);
                if (Resualt.Succeeded)
                {
                    return RedirectToAction("Index", "AppUser");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password not correct..!");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();

            return RedirectToAction(nameof(Signin));
        }
    }
}
