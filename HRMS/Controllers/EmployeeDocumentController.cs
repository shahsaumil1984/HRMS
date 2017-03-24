using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Service;
using Model;
namespace HRMS
{
    public class EmployeeDocumentController : Controller
    {
        // GET: EmployeeDocument
        [Authorize(Roles = "Admin")]
        public ActionResult Index(int EmployeeID)
        {

            MasterViewModel obj = new MasterViewModel();
            Service.DocumentTypeService service = new Service.DocumentTypeService();
            obj.DocumentTypes = service.Get().ToList();

            ViewBag.EmployeeID = EmployeeID;
            return View(obj);

        }

        public JsonResult AjaxUpload(HttpPostedFileBase file, int EmployeeID, int DocumentTypeID=1)
        {
            Document entity = new Document();
            EmployeeDocument ed = new EmployeeDocument();
            DocumentService documentService = new DocumentService();
            EmployeeDocumentService employeeDocumentService = new EmployeeDocumentService();

            entity.DocumentContent = new byte[file.InputStream.Length];
            file.InputStream.Read(entity.DocumentContent, 0, entity.DocumentContent.Length);
            entity.DocumentName = file.FileName;
            entity.CreatedBy = "jpithadiya@affirma.com";
            entity.ModifiedBy = "jpithadiya@affirma.com";
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            documentService.Create(entity);
            long id = documentService.SaveChangesReturnId(entity);

            
            ed.EmployeeID = EmployeeID;
            ed.DocumentID = id;
            ed.DocumentTypeID = DocumentTypeID;
            ed.DocumentName = file.FileName;
            ed.CreatedBy = "jpithadiya@affirma.com";
            ed.CreatedDate = DateTime.Now;

            employeeDocumentService.Create(ed);
            employeeDocumentService.SaveChanges();

            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public FileContentResult FileDownload(int id)
        {
            //declare byte array to get file content from database and string to store file name
            byte[] fileData;
            string fileName;

            DocumentService service = new DocumentService();

            var record = service.GetById(id);

            //only one record will be returned from database as expression uses condtion on primary field
            //so get first record from returned values and retrive file content (binary) and filename
            fileData = (byte[])record.DocumentContent.ToArray();
            fileName = record.DocumentName;
            //return file and provide byte file content and file name
            return File(fileData, "text", fileName);

        }
    }
}