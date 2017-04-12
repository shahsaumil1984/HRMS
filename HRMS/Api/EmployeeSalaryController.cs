using Api;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace HRMS.Api
{
    public class EmployeeSalaryController : GenericApiController<EmployeeService, Employee, int>, IGetList
    {
        //// GET: EmployeeSalary
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public override object GetModel()
        {
            Employee obj = (Employee)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        public override Employee GetById(int id)
        {
            service.Context.Configuration.ProxyCreationEnabled = false;

            Employee obj = (from o in service.Context.Employees
                            where o.EmployeeID == id
                            select new
                            {

                                o.EmployeeID,
                                o.FirstName,
                                o.LastName,
                                o.FullName,
                                o.Email,
                                o.Phone,
                                o.PermanentAddressLine1,
                                o.PermanentAddressLine2,
                                o.PermanentAddressLine3,
                                o.PermanentAddressState,
                                o.PermanentAddressCountry,
                                o.PermanentAddressZip,
                                o.AddressLine1,
                                o.AddressLine2,
                                o.AddressLine3,
                                o.AddressState,
                                o.AddressCountry,
                                o.AddressZip,
                                o.DateOfBirth,
                                o.DateOfjoining,
                                o.ProbationPeriodEndDate,
                                o.HasResigned,
                                o.DateOfResignation,
                                o.LastWorkingDay,
                                o.PAN,
                                o.IDCardNumber,
                                o.IDCardType,
                                o.SalaryAccountNumber,
                                o.SalaryAccountBank,
                                o.SalaryAccountBankAddress,
                                o.SalaryAccountIFSCCode,
                                o.AddressCity,
                                o.PermanentAddressCity,
                                o.DesignationID,
                                o.EmployeePhoto,
                                o.EmployeeStatu

                            }).ToList().Select(o => new Employee
                            {
                                EmployeeID = o.EmployeeID,
                                FirstName = o.FirstName,
                                LastName = o.LastName,
                                FullName = o.FullName,
                                Email = o.Email,
                                Phone = o.Phone,
                                PermanentAddressLine1 = o.PermanentAddressLine1,
                                PermanentAddressLine2 = o.PermanentAddressLine2,
                                PermanentAddressLine3 = o.PermanentAddressLine3,
                                PermanentAddressState = String.IsNullOrEmpty(o.PermanentAddressState) ? "Select" : o.PermanentAddressState.Trim(),
                                PermanentAddressCountry = o.PermanentAddressCountry,
                                PermanentAddressZip = o.PermanentAddressZip,
                                AddressLine1 = o.AddressLine1,
                                AddressLine2 = o.AddressLine2,
                                AddressLine3 = o.AddressLine3,
                                AddressState = String.IsNullOrEmpty(o.AddressState) ? "Select" : o.AddressState.Trim(),
                                AddressCountry = o.AddressCountry,
                                AddressZip = o.AddressZip,
                                DateOfBirth = o.DateOfBirth,
                                DateOfjoining = o.DateOfjoining,
                                ProbationPeriodEndDate = o.ProbationPeriodEndDate,
                                HasResigned = o.HasResigned,
                                DateOfResignation = o.DateOfResignation,
                                LastWorkingDay = o.LastWorkingDay,
                                PAN = o.PAN,
                                IDCardNumber = o.IDCardNumber,
                                IDCardType = o.IDCardType,
                                SalaryAccountNumber = o.SalaryAccountNumber,
                                SalaryAccountBank = o.SalaryAccountBank,
                                SalaryAccountBankAddress = o.SalaryAccountBankAddress,
                                SalaryAccountIFSCCode = o.SalaryAccountIFSCCode,
                                AddressCity = o.AddressCity,
                                PermanentAddressCity = o.PermanentAddressCity,
                                DesignationID = o.DesignationID,
                                EmployeePhoto = o.EmployeePhoto,
                                EmployeeStatu = o.EmployeeStatu

                            }).Single<Employee>();
            return obj;
        }

        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            int month = 4;
            int year = 2017;

            IQueryable<Employee> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = (from o in list
                         where o.EmployeeStatusID != (int)Helper.EmployeeStatus.InActive
                         select new
                         {
                             o.EmployeeID,
                             o.FirstName,
                             o.LastName,
                             o.FullName,
                             o.Email,
                             o.Phone,
                             o.PermanentAddressLine1,
                             o.PermanentAddressLine2,
                             o.PermanentAddressLine3,
                             o.PermanentAddressState,
                             o.PermanentAddressCountry,
                             o.PermanentAddressZip,
                             o.AddressLine1,
                             o.AddressLine2,
                             o.AddressLine3,
                             o.AddressState,
                             o.AddressCountry,
                             o.AddressZip,
                             o.DateOfBirth,
                             o.DateOfjoining,
                             o.ProbationPeriodEndDate,
                             o.HasResigned,
                             o.DateOfResignation,
                             o.LastWorkingDay,
                             o.PAN,
                             o.IDCardNumber,
                             o.IDCardType,
                             o.SalaryAccountNumber,
                             o.SalaryAccountBank,
                             o.SalaryAccountBankAddress,
                             o.SalaryAccountIFSCCode,
                             o.AddressCity,
                             o.PermanentAddressCity,
                             o.EmployeePhoto,
                             o.Salaries
                         }).AsEnumerable().Select(x => new
                         {
                             EmployeeID = x.EmployeeID,
                             FirstName = x.FirstName,
                             LastName = x.LastName,
                             FullName = x.FullName,
                             Email = x.Email,
                             Phone = x.Phone,
                             PermanentAddressLine1 = x.PermanentAddressLine1,
                             PermanentAddressLine2 = x.PermanentAddressLine2,
                             PermanentAddressLine3 = x.PermanentAddressLine3,
                             PermanentAddressState = x.PermanentAddressState,
                             PermanentAddressCountry = x.PermanentAddressCountry,
                             PermanentAddressZip = x.PermanentAddressZip,
                             AddressLine1 = x.AddressLine1,
                             AddressLine2 = x.AddressLine2,
                             AddressLine3 = x.AddressLine3,
                             AddressState = x.AddressState,
                             AddressCountry = x.AddressCountry,
                             AddressZip = x.AddressZip,
                             DateOfBirth = x.DateOfBirth,
                             DateOfjoining = x.DateOfjoining,
                             ProbationPeriodEndDate = x.ProbationPeriodEndDate,
                             HasResigned = x.HasResigned,
                             DateOfResignation = x.DateOfResignation,
                             LastWorkingDay = x.LastWorkingDay,
                             PAN = x.PAN,
                             IDCardNumber = x.IDCardNumber,
                             IDCardType = x.IDCardType,
                             SalaryAccountNumber = x.SalaryAccountNumber,
                             SalaryAccountBank = x.SalaryAccountBank,
                             SalaryAccountBankAddress = x.SalaryAccountBankAddress,
                             SalaryAccountIFSCCode = x.SalaryAccountIFSCCode,
                             AddressCity = x.AddressCity,
                             PermanentAddressCity = x.PermanentAddressCity,
                             EmployeePhoto = x.EmployeePhoto,
                             SalaryStatus = x.Salaries.Where(s => s.Month.Month1 == month && s.Month.Year == year).FirstOrDefault() == null ? "Pending" : x.Salaries.Where(s => s.Month.Month1 == month && s.Month.Year == year).FirstOrDefault().SalaryStatu.SalaryStatusName
                         }).AsQueryable();

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }

        [HttpGet]
        public int GetNextEmployeeID(int EmployeeID)
        {
            int nextEmpID = -1;
            List<Employee> emplist = service.Get().OrderBy(m => m.EmployeeCode).ToList();
            int empIndex = emplist.FindIndex(m => m.EmployeeID == EmployeeID);
            var emp = emplist.Skip(empIndex + 1).Take(1).FirstOrDefault();
            if (emp != null)
                nextEmpID = emp.EmployeeID;
            return nextEmpID;
        }

        [HttpGet]
        public int GetPrevEmployeeID(int EmployeeID)
        {
            int nextEmpID = -1;
            List<Employee> emplist = service.Get().OrderBy(m => m.EmployeeCode).ToList();
            int empIndex = emplist.FindIndex(m => m.EmployeeID == EmployeeID);
            if (empIndex > 0)
            {
                var emp = emplist.Skip(empIndex - 1).Take(1).FirstOrDefault();
                if (emp != null)
                    nextEmpID = emp.EmployeeID;
            }
            return nextEmpID;
        }

        [HttpGet]
        public HttpResponseMessage GetDownloadPDF(int EmpID, int MonthID)
        {
            SalaryService salService = new SalaryService();
            Salary sObj = salService.Get().Where(s => s.EmployeeID == EmpID && s.MonthID == MonthID).FirstOrDefault();
            return SetSalaryDetails(sObj);
        }

        public HttpResponseMessage SetSalaryDetails(Salary salObj)
        {
            try
            {
                //-- Generate file
                var wordFile = salObj.Employee.FirstName + " " + salObj.Employee.LastName + " - " + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(salObj.Month.Month1) + "-" + (salObj.Month.Year % 100) + ".docx";
                var ms = new MemoryStream();
                Byte[] ByteArray = null;                

                using (MemoryStream generatedDocument = new MemoryStream())
                {
                    using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                    {
                        GeneratedClass gc = new GeneratedClass();
                        gc.SalaryObj = salObj;
                        gc.CreateParts(package);
                    }

                    ByteArray = generatedDocument.ToArray();
                    File.WriteAllBytes(wordFile, ByteArray);
                }

                var pdfFile = salObj.Employee.FirstName + " " + salObj.Employee.LastName + " - " + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(salObj.Month.Month1) + "-" + (salObj.Month.Year % 100) + ".pdf";
                //Read the Data from word File
                //using (StreamReader rdr = new StreamReader(wordFile))
                //{
                //    //Create a New instance on Document Class
                //    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                //    //Create a New instance of PDFWriter Class for Output File
                //    PdfWriter.GetInstance(doc, new FileStream(pdfFile, FileMode.Create));

                //    //Open the Document
                //    doc.Open();

                //    //Add the content of Text File to PDF File

                //    doc.Add(new Paragraph(rdr.ReadToEnd()));

                //    //Close the Document

                //    doc.Close();
                //}



                //Download PDF file
                var stream = new FileStream(wordFile, FileMode.Open, FileAccess.Read);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = wordFile
                };

                return response;
                
            }
            catch (Exception e)
            {
                return HttpError(e);
            }
        }

    }
}