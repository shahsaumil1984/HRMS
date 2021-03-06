﻿using System;
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
using ViewModel;

namespace HRMS
{
    public class EmployeeStatusHistoryController : BaseController
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



        // GET: ManageStatus
        [Authorize(Roles = "Admin")]
        public ActionResult Index(int employeeID)
        {
            EmployeeStatusService de = new EmployeeStatusService();
            HRMSEntities entity = new HRMSEntities();
            var d = entity.Employees.Find(employeeID);
            if (d != null)
            {
                ViewBag.FullName = d.FullName;
            }
            ViewBag.EmployeeID = employeeID;
            
            MasterViewModel obj = new MasterViewModel();
            obj.EmployeeStatus = de.Get().ToList();
            return View(obj);
        }

    }
    public class ManageEmployeeStatus: Controller
    {
        public List<EmployeeStatusHistory> EmployeeStatusHistory { get; set; }
        public List<EmployeeStatu> EmployeeStatuses { get; set; }
        public Employee Employee { get; set; }

    }
}

