
using System.Web.Mvc;

namespace HRMS
{
  public class EmployeeController : Controller
  {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            
            return View();

        }
  }
}
      