using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model;
using Service;

namespace HRMS.Controllers
{
    public class ManageRolesController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }



        // GET: ManageRoles
        public ActionResult Index(int employeeID)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            List<IdentityRole> roles = roleManager.Roles.ToList();
            EmployeeRoles empRole = new EmployeeRoles();
            List<string> lstExistingRoles = new List<string>();
            List<string> lstRoles = new List<string>();
            
            AspNetUserService aspNetUserService = new AspNetUserService();
            AspNetUser objAspNetUser = aspNetUserService.Get().Where(m => m.EmployeeId == employeeID).FirstOrDefault();
            if (objAspNetUser != null)
            {
                string userId = objAspNetUser.Id;
                if (!string.IsNullOrEmpty(userId))
                {
                    foreach (var item in roles)
                    {
                        bool hasRole = false;
                        hasRole = UserManager.IsInRole(userId, item.Name);
                        if (hasRole)
                            lstExistingRoles.Add(item.Name);
                        else
                            lstRoles.Add(item.Name);
                    }
                }
            }
            
            empRole.lstRoles = lstRoles;
            empRole.lstExistingRoles = lstExistingRoles;
            ViewBag.EmployeeID = employeeID;
            return View(empRole);
        }

        public JsonResult SaveRoles(string strRoles, int employeeID)
        {
            string msg = "";
            AspNetUserService aspNetUserService = new AspNetUserService();
            AspNetUser objAspNetUser = aspNetUserService.Get().Where(m => m.EmployeeId == employeeID).FirstOrDefault();
            if (objAspNetUser != null)
            {
                string userId = objAspNetUser.Id;
                if (!string.IsNullOrEmpty(userId))
                {
                    IList<string> lstexistingRoles = UserManager.GetRoles(userId);
                    foreach (var item in lstexistingRoles)
                    {
                        UserManager.RemoveFromRole(userId, item);
                    }
                    if (!string.IsNullOrEmpty(strRoles))
                    {
                        string[] lstRoles;
                        lstRoles = strRoles.Split(',');
                        foreach (var item in lstRoles)
                        {
                            if (!UserManager.IsInRole(userId, item))
                                UserManager.AddToRole(userId, item);
                        }
                        msg = "All roles added!";
                    }
                    else
                        msg = "No roles selected";
                }
                else
                    msg = "User does not exist.";
            }
            else
                msg = "User does not exist.";
            return new JsonResult { Data = msg, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }

    public class EmployeeRoles
    {
        public List<string> lstRoles { get; set; }
        public List<string> lstExistingRoles { get; set; }
        public string str { get; set; }
    }
}

