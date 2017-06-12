using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS
{
    public class EmployeeStatusController : BaseController
    {
        // GET: DocumentType
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
             return View();
        }
    }
}