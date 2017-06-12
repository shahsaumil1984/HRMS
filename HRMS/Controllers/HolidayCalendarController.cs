
using System.Web.Mvc;

namespace HRMS
{
  public class HolidayCalendarController : BaseController
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
  }
}
      