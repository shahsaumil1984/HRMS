using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS
{
    public class EmployeeDocumentController : Controller
    {
        // GET: EmployeeDocument
        public ActionResult Index()
        {
            ViewBag.EmployeeID =HttpContext.Request.QueryString["EmployeeID"];
            return View();
        }
    }
}