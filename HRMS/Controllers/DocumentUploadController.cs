using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace HRMS.Controllers
{
    public class DocumentUploadController : Controller
    {
        // GET: DocumentUpload
        HRMSEntities dbContext = new HRMSEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjaxUpload(HttpPostedFileBase file,Document entity)
        {
            var fileName = file.FileName;
            
            entity.DocumentContent = new byte[file.InputStream.Length];
            file.InputStream.Read(entity.DocumentContent, 0, entity.DocumentContent.Length);
            
            dbContext.Documents.Add(entity);
            dbContext.SaveChanges();


            // now you could pass the byte array to your model and store wherever 
            // you intended to store it

            return Content("Thanks for uploading the file: "+ file.FileName);
        }

    }
}