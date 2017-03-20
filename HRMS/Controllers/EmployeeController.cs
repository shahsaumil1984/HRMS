
using System.Web.Mvc;

namespace ControllerFile
{
  public class EmployeeController : Controller
  {   
     public ActionResult Index()
        {
            int a = 0;
            int b = a + 5;
            return View();

        }
  }
}
      