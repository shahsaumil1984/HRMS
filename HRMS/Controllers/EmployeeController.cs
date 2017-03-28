using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using ViewModel;
using Service;
using System.Web.Mvc;

namespace HRMS
{
  public class EmployeeController : Controller
  {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            MasterViewModel obj = new MasterViewModel();
            Service.DesignationTypeService service = new Service.DesignationTypeService();
            obj.Designations = service.Get().ToList();
            return View(obj);

        }
  }
}
      