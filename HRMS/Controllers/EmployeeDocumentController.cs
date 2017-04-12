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
            AspNetUserService aspNetUserService = new AspNetUserService();
            AspNetUser objAspNetUser = aspNetUserService.Get().Where(m => m.EmployeeId == EmployeeID).FirstOrDefault();
            if (objAspNetUser != null)
            {
                ViewBag.UserName = objAspNetUser.FirstName + " " + objAspNetUser.LastName;
                ViewBag.EmployeeID = EmployeeID;

                MasterViewModel obj = new MasterViewModel();
                Service.DocumentTypeService service = new Service.DocumentTypeService();
                obj.DocumentTypes = service.Get().ToList();
                
                return View(obj);
            }
            else
            {
                //navigate to error page              
                return View("Error", new ErrorViewModel
                {
                    Summary = "Error: Employee does not exist",
                    Description = "EmployeeID parameter entered in the URL does not exist."
                });
            }
        }

        [Authorize(Roles = "Admin")]
        public JsonResult AjaxUpload(HttpPostedFileBase file, int EmployeeID, int DocumentTypeID=1)
        {
            Document entity = new Document();
            EmployeeDocument ed = new EmployeeDocument();
            DocumentService documentService = new DocumentService();
            EmployeeDocumentService employeeDocumentService = new EmployeeDocumentService();
            long id = 0;
            var employeeDocument = employeeDocumentService.Get().Where(i => i.DocumentTypeID == DocumentTypeID && i.EmployeeID == EmployeeID).FirstOrDefault();

            entity.DocumentContent = new byte[file.InputStream.Length];
            file.InputStream.Read(entity.DocumentContent, 0, entity.DocumentContent.Length);
            entity.DocumentName = file.FileName;
            entity.CreatedBy = "jpithadiya@affirma.com";
            entity.ModifiedBy = "jpithadiya@affirma.com";
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            documentService.Create(entity);
            id = documentService.SaveChangesReturnId(entity);

            
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

        [Authorize(Roles = "Admin")]
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