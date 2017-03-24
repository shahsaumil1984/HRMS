
using System.Web.Mvc;

namespace HRMS
{
  public class HolidayCalendarController : Controller
  {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
  }
}
      