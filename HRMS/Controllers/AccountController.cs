using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;
using System.Web.Security;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;



namespace HRMS.Controllers
{
    public class AccountController : Controller
    {


        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Error = "";
            return View();
        }        

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        // GET: Account
        public ActionResult Index()
        {

            //Service.AspNetUserService service = new Service.AspNetUserService();

            //foreach (var user in service.Get())
            //{

            //    string UserId = user.Id;
            //    var token = UserManager.GeneratePasswordResetToken(UserId);
            //    var result =  UserManager.ResetPasswordAsync(UserId, token, "Test123$");
            //}

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {

            try
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        {
                            Service.AspNetUserService service = new Service.AspNetUserService();
                            Session["UserDetails"] = service.GetLoggedinUserDetails(model.Email);
                            return RedirectToLocal(returnUrl);
                        }
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "Invalid login attempt.");
                        ViewBag.ReturnUrl = returnUrl;
                        ViewBag.Error = "Message";
                        //return RedirectToAction("Index");
                        return View(model);
                }
            }
            catch (Exception ex)
            {
            }
            return View(model);
        }

        public ActionResult Logout(LoginViewModel model, string returnUrl)
        {
            AuthenticationManager.SignOut();
            Session.Clear();
            return RedirectToAction("Index");
        }



        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Employee");
        }


        public ActionResult AccessDenied()
        {
            return View();
        }

    }
}