using System;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using SB.Models;

namespace SB.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private SBData db = new SBData();

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Login u)
        {

            if (!ModelState.IsValid)
            {
                return View(u);
            }

            using (SBData dc = new SBData())
            {
                var v = dc.UserSys.Include("Role").Where(a => a.Email.Equals(u.Email) && a.Password.Equals(u.Password)).FirstOrDefault();
                if (v != null)
                {
                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, v.Login),
                        new Claim(ClaimTypes.NameIdentifier, v.Id.ToString()),
                        new Claim(ClaimTypes.Email, v.Email),
                        new Claim(ClaimTypes.Role, v.Role.Name)
                    }, "ApplicationCookie");

                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;

                    authManager.SignIn(identity);

                    u.ReturnUrl = v.Role.IsAdmin ? "/Customers" : string.Format("/Customers?sellerId={0}", v.Id);

                    return Redirect(u.ReturnUrl);

                }
                else
                {
                    ModelState.AddModelError("", "The email and/or password entered is invalid.Please try again");
                    return View();
                }

            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
