using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using ViewModel;
using Service;

namespace HRMS
{
  public class EmployeeController : BaseController
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            MasterViewModel obj = new MasterViewModel();
            DesignationTypeService service = new Service.DesignationTypeService();
            EmployeeStatusService eservice = new EmployeeStatusService();

            obj.Designations = service.Get().ToList();
            obj.EmployeeStatus = eservice.Get().ToList();
            return View(obj);

        }
  }
}
      