using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Service;
namespace HRMS
{
    public class EmployeeDocumentController : Controller
    {
        // GET: EmployeeDocument
        public ActionResult Index()
        {
            
            MasterViewModel obj = new MasterViewModel();
            Service.DocumentTypeService service = new Service.DocumentTypeService();
            obj.DocumentTypes = service.Get().ToList();


            return View(obj);
            
        }

        public JsonResult AjaxUpload(HttpPostedFileBase file, int EmployeeID, int DocumentTypeID)
        {
            Document entity = new Document();
            entity.DocumentContent = new byte[file.InputStream.Length];
            file.InputStream.Read(entity.DocumentContent, 0, entity.DocumentContent.Length);
            entity.DocumentName = file.FileName;

            DocumentService service = new DocumentService();
            service.Create(entity);
            int id = service.SaveChangesReturnId(entity);

            EmployeeDocument ed = new EmployeeDocument();
            ed.EmployeeID = EmployeeID;
            ed.DocumentTypeID = DocumentTypeID;
            ed.DocumentName = file.FileName;


            return Json("Success", JsonRequestBehavior.AllowGet);


        }

        public FileContentResult FileDownload(int id)
        {
            //declare byte array to get file content from database and string to store file name
            byte[] fileData;
            string fileName;

            var record = from p in dbContext.Documents
                         where p.DocumentID == id
                         select p;
            //only one record will be returned from database as expression uses condtion on primary field
            //so get first record from returned values and retrive file content (binary) and filename
            fileData = (byte[])record.First().DocumentContent.ToArray();
            fileName = record.First().DocumentName;
            //return file and provide byte file content and file name
            return File(fileData, "text", fileName);

        }
    }
}