using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNiVERSiTYwebapp.Models;

namespace UNiVERSiTYwebapp.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Role
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) {
                if (!isAdminUser())
                    return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index", "Home");

            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<User>(new UserStore<User>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Administrator")
                    return true;
            }
            return false;
        }
    }
}