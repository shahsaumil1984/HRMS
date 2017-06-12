
using System.Web.Mvc;

namespace HRMS
{
  public class LeaveTypeController : BaseController
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
  }
}
      