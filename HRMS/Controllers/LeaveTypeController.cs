
using System.Web.Mvc;

namespace HRMS
{
  public class LeaveTypeController : Controller
  {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
  }
}
      