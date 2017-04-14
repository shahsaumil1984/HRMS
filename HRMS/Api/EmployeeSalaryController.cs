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
using Ionic.Zip;


namespace HRMS.Api
{
    public class EmployeeSalaryController : GenericApiController<EmployeeService, Employee, int>, IGetList
    {
        //// GET: EmployeeSalary
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Accountant")]
        public override object GetModel()
        {
            Employee obj = (Employee)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        [Authorize(Roles = "Accountant")]
        public override Employee GetById(int id)
        {
            service.Context.Configuration.ProxyCreationEnabled = false;

            Employee obj = (from o in service.Context.Employees
                            where o.EmployeeID == id
                            select new
                            {

                                o.EmployeeID,
                                o.EmployeeCode,
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
                                EmployeeStatu = o.EmployeeStatu,
                                EmployeeCode = o.EmployeeCode

                            }).Single<Employee>();
            return obj;
        }

        [Authorize(Roles = "Accountant")]
        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            int monthID = Convert.ToInt32(includeProperties.Substring(includeProperties.IndexOf('=') + 1));

            IQueryable<Employee> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = (from o in list
                         where o.EmployeeStatusID != (int)Helper.EmployeeStatus.InActive
                         select new
                         {
                             o.EmployeeID,
                             o.EmployeeCode,
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
                             EmployeeCode = x.EmployeeCode,
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
                             SalaryStatus = x.Salaries.Where(s => s.MonthID == monthID).FirstOrDefault() == null ? "Pending" : x.Salaries.Where(s => s.MonthID == monthID).FirstOrDefault().SalaryStatu.SalaryStatusName
                         }).AsQueryable();

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }

        [HttpGet]
        [Authorize(Roles = "Accountant")]
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
        [Authorize(Roles = "Accountant")]
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
        [Authorize(Roles = "Accountant")]
        public HttpResponseMessage GetDownloadPDF(int EmpID, int MonthID)
        {
            SalaryService salService = new SalaryService();
            Salary sObj = salService.Get().Where(s => s.EmployeeID == EmpID && s.MonthID == MonthID).FirstOrDefault();
            List<Salary> salList = new List<Salary> { sObj };
            return Download(salList, false);
        }

        [HttpGet]
        [Authorize(Roles = "Accountant")]
        public HttpResponseMessage GetDownloadPDFZip(int MonthID)
        {
            SalaryService salService = new SalaryService();
            List<Salary> approvedSalaryList = salService.Get().Where(s => s.MonthID == MonthID && s.SalaryStatus == (int)Helper.SalaryStatus.Approved && s.Employee.EmployeeStatusID != (int)Helper.EmployeeStatus.InActive).ToList();
            return Download(approvedSalaryList, true);
        }

        #region Private Methods
        private HttpResponseMessage Download(List<Salary> salList, bool isZip)
        {
            var ms = new MemoryStream();
            Byte[] ByteArray = null;
            string file = string.Empty;

            string month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(salList.FirstOrDefault().Month.Month1);

            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                //string archiveDirectory = "SalarySlips_" + month;
                //zip.AddDirectoryByName(archiveDirectory);


                foreach (Salary salObj in salList)
                {
                    file = salObj.Employee.FirstName + " " + salObj.Employee.LastName + " - " + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(salObj.Month.Month1) + "-" + (salObj.Month.Year % 100) + ".docx";
                    using (MemoryStream generatedDocument = new MemoryStream())
                    {
                        using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                        {
                            GeneratedClass gc = new GeneratedClass();
                            gc.SalaryObj = salObj;
                            gc.CreateParts(package);

                        }
                        ByteArray = generatedDocument.ToArray();
                        File.WriteAllBytes(file, ByteArray);
                    }
                    if (isZip)
                    {
                        zip.AddFile(file);
                    }
                }

                if (!isZip)
                {
                    var stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StreamContent(stream);

                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = file
                    };

                    return response;
                }
                else
                {
                    //Download Zip file
                    var pushStreamContent = new PushStreamContent((stream, content, context) =>
                    {
                        zip.Save(stream);
                        stream.Close();
                    }, "application/zip");

                    return new HttpResponseMessage(HttpStatusCode.OK) { Content = pushStreamContent };

                }
            }

        }
        #endregion
    }
}