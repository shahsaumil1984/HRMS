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
            List<string> lstRoles = new List<string>();
            foreach (var item in roles)
            {
                lstRoles.Add(item.Name);
            }
            empRole.lstRoles = lstRoles;
            ViewBag.EmployeeID = employeeID;
            return View(empRole);
        }


        //public async Task<ActionResult> SaveRoles(string strRoles)
        public JsonResult SaveRoles(string strRoles, int employeeID)
        {
            string msg = "";
            //   int employeeID = Convert.ToInt32(Request.QueryString["EmployeeID"]);

            EmployeeService empService = new EmployeeService();
            Employee emp= empService.GetById(employeeID);
            string email = emp.Email;
            //  ApplicationUser objAppUser = UserManager.FindByName(email);
            UserManager.GetRoles(email);
            if (!string.IsNullOrEmpty(strRoles))
            {
                string[] lstRoles;
                lstRoles = strRoles.Split(',');
                foreach (var item in lstRoles)
                {
                    if (!UserManager.IsInRole("e5f6374d-4f57-4794-a8f6-761a39f4ebfe", item))
                        UserManager.AddToRole("e5f6374d-4f57-4794-a8f6-761a39f4ebfe", item);

                }
                msg = "All roles added!";
            }
            else
                msg = "No roles selected";
            return new JsonResult { Data = msg, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            // return View();
        }
    }

    public class EmployeeRoles
    {
        public List<string> lstRoles { get; set; }
        public string str { get; set; }
    }
}

