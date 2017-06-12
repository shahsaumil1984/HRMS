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
    public class DocumentUploadController : BaseController
    {
        // GET: DocumentUpload
        HRMSEntities dbContext = new HRMSEntities();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            MasterViewModel obj = new MasterViewModel();
            Service.DocumentTypeService service = new Service.DocumentTypeService();
            obj.DocumentTypes = service.Get().ToList();


            return View(obj);
        }

       

    }
}