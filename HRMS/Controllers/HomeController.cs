﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize(Roles= "Admin,Accountant")]
        public ActionResult Index()
        {
            return View();
        }
    }
}