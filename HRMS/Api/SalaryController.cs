using HRMS;
using Model;
using Service;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Configuration;
using static HRMS.Helper;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using Ionic.Zip;
using System.Net;
using System.Net.Http.Headers;
using System.Linq.Dynamic;

namespace Api
{
    public class SalaryController : GenericApiController<SalaryService, Salary, int>, IGetList
    {
        //// GET: Salary
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Accountant")]
        public override object GetModel()
        {
            Salary obj = (Salary)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        [Authorize(Roles = "Accountant")]
        public override Salary GetById(int id)
        {


            Salary obj = (from o in service.Context.Salaries
                          where o.SalaryID == id
                          select new
                          {
                              o.SalaryID,
                              o.Advance,
                              o.AdvanceSalary,
                              o.Basic,
                              o.ConveyanceAllowance,
                              o.EmployeeID,
                              o.EPF,
                              o.Exgratia,
                              o.HRA,
                              o.Incentive,
                              o.Leave,
                              o.MedicalReimbursement,
                              o.Month,
                              o.MonthID,
                              o.OtherAllowance,
                              o.PLI,
                              o.ProfessionalTax,
                              o.ReimbursementOfexp,
                              o.TDS,
                              o.YTDS,
                              o.AccountNumber,
                              o.SalaryStatus,
                              o.BankName,
                              o.SalaryStatu

                          }).ToList().Select(o => new Salary
                          {

                              SalaryID = o.SalaryID,
                              Advance = o.Advance,
                              AdvanceSalary = o.AdvanceSalary,
                              Basic = o.Basic,
                              ConveyanceAllowance = o.ConveyanceAllowance,
                              EmployeeID = o.EmployeeID,
                              EPF = o.EPF,
                              Exgratia = o.Exgratia,
                              HRA = o.HRA,
                              Incentive = o.Incentive,
                              Leave = o.Leave,
                              MedicalReimbursement = o.MedicalReimbursement,
                              Month = o.Month,
                              MonthID = o.MonthID,
                              OtherAllowance = o.OtherAllowance,
                              PLI = o.PLI,
                              ProfessionalTax = o.ProfessionalTax,
                              ReimbursementOfexp = o.ReimbursementOfexp,
                              TDS = o.TDS,
                              YTDS = o.YTDS,
                              AccountNumber = o.AccountNumber,
                              SalaryStatus = o.SalaryStatus,
                              BankName = o.BankName,
                              SalaryStatu = o.SalaryStatu
                          }).Single<Salary>();
            return obj;
        }

        [HttpPost]
        [Authorize(Roles = "Accountant")]
        public Salary GetByMonth(int employeeID, int monthID, bool checkPrevious)
        {
            if (checkPrevious)
            {
                var prevMonthID = (monthID - 1);
                monthID = prevMonthID;
            }

            service.Context.Configuration.ProxyCreationEnabled = false;
            var objSalary = (from o in service.Context.Salaries
                             where o.EmployeeID == employeeID && o.MonthID == monthID
                             select new
                             {
                                 o.SalaryID,
                                 o.Advance,
                                 o.AdvanceSalary,
                                 o.Basic,
                                 o.ConveyanceAllowance,
                                 o.EmployeeID,
                                 o.EPF,
                                 o.Exgratia,
                                 o.HRA,
                                 o.Incentive,
                                 o.Leave,
                                 o.MedicalReimbursement,
                                 o.Month,
                                 o.MonthID,
                                 o.OtherAllowance,
                                 o.PLI,
                                 o.ProfessionalTax,
                                 o.ReimbursementOfexp,
                                 o.TDS,
                                 o.YTDS,
                                 o.Total,
                                 o.TotalPayment,
                                 o.Salary1,
                                 o.Note,
                                 o.SalaryStatu,
                                 o.BankName,
                                 o.AccountNumber,
                                 //IStart Jay Pithadiya 21/4/2017, Added this to keep created by when editing Salary details
                                 o.CreatedBy,
                                 o.CreatedDate,
                                 //IEnd Jay Pithadiya 21/4/2017, Added this to keep created by when editing Salary details

                             }).ToList();


            Salary obj = objSalary.Select(o => new Salary
            {

                SalaryID = o.SalaryID,
                Advance = o.Advance,
                AdvanceSalary = o.AdvanceSalary,
                Basic = o.Basic,
                ConveyanceAllowance = o.ConveyanceAllowance,
                EmployeeID = o.EmployeeID,
                EPF = o.EPF,
                Exgratia = o.Exgratia,
                HRA = o.HRA,
                Incentive = o.Incentive,
                Leave = o.Leave,
                MedicalReimbursement = o.MedicalReimbursement,
                Month = o.Month,
                MonthID = o.MonthID,
                OtherAllowance = o.OtherAllowance,
                PLI = o.PLI,
                ProfessionalTax = o.ProfessionalTax,
                ReimbursementOfexp = o.ReimbursementOfexp,
                TDS = o.TDS,
                YTDS = o.YTDS,
                Total = o.Total,
                TotalPayment = o.TotalPayment,
                Salary1 = o.Salary1,
                //SalaryStatusName = o.SalaryStatusName,
                BankName = o.BankName,
                AccountNumber = o.AccountNumber,
                Note = o.Note,
                SalaryStatu = o.SalaryStatu,
                //IStart Jay Pithadiya 21/4/2017, Added this to keep created by when editing Salary details
                CreatedBy = o.CreatedBy,
                CreatedDate = o.CreatedDate,
                //IEnd Jay Pithadiya 21/4/2017, Added this to keep created by when editing Salary details

            }).SingleOrDefault<Salary>();
                        
            if (obj == null)            
                obj = new Salary() { EmployeeID = employeeID, MonthID = monthID };            
            return obj;
        }

        [Authorize(Roles = "Accountant")]
        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<Salary> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = from o in list
                        select new
                        {
                            o.SalaryID,
                            o.Advance,
                            o.AdvanceSalary,
                            o.Basic,
                            o.ConveyanceAllowance,
                            o.EmployeeID,
                            o.EPF,
                            o.Exgratia,
                            o.HRA,
                            o.Incentive,
                            o.Leave,
                            o.MedicalReimbursement,
                            o.Month,
                            o.MonthID,
                            o.OtherAllowance,
                            o.PLI,
                            o.ProfessionalTax,
                            o.ReimbursementOfexp,
                            o.TDS,
                            o.YTDS
                        };

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }

        [HttpPost]
        [Authorize(Roles = "Accountant")]
        public HttpResponseMessage UploadCSV()
        {
            try
            {
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedCSV"];
                //string filePath = HttpContext.Current.Server.MapPath("~/UploadedCSV/" + httpPostedFile.);
                //httpPostedFile.SaveAs(filePath);

                //Creating object of datatable  
                DataTable tblcsv = new DataTable();

                //string CSVFilePath = Path.GetFullPath(filePath);

                //Reading All text  
                string ReadCSV = string.Empty;

                using (var reader = new StreamReader(httpPostedFile.InputStream, Encoding.UTF8))
                {
                    ReadCSV = reader.ReadToEnd();
                }

                string[] csvRows = ReadCSV.Split('\n');
                //spliting row after new line  
                foreach (string csvRow in csvRows)
                {
                    if (!string.IsNullOrEmpty(csvRow))
                    {
                        //Adding each row into datatable  

                        if (csvRows.First().Equals(csvRow))
                        {
                            foreach (string fileHeader in csvRow.Split(','))
                            {
                                tblcsv.Columns.Add(Regex.Replace(fileHeader, @"\t|\n|\r", ""));
                            }
                        }
                        else
                        {
                            tblcsv.Rows.Add();
                            int count = 0;
                            foreach (string FileRec in csvRow.Split(','))
                            {
                                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = Regex.Replace(FileRec, @"\t|\n|\r", "");
                                count++;
                            }
                        }
                    }
                }
                //Calling insert Functions  
                InsertCSVRecords(tblcsv);
                return HttpSuccess();
            }
            catch (Exception e)
            {
                return HttpError(e);
            }
        }

        [Authorize(Roles = "Accountant")]
        public override HttpResponseMessage Create(Salary entity)
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            int CurrentDay = DateTime.Now.Day;
            DateTime PreviousMonthDate = DateTime.Now.AddMonths(-1);
            int PreviousMonth = PreviousMonthDate.Month;
            int PreviousYear = PreviousMonthDate.Year;

            Model.Month objMonth = service.Context.Months.Where(m => m.MonthID == entity.MonthID).FirstOrDefault();
            if (objMonth != null && ((objMonth.Month1 == currentMonth && objMonth.Year == currentYear)
                || (objMonth.Month1 == PreviousMonth && objMonth.Year == PreviousYear && CurrentDay <= 5)))
            {
                if (entity.SalaryStatus == (int)SalaryStatus.Approved)
                    entity.SalaryStatus = Convert.ToInt32(SalaryStatus.Approved);
                else
                    entity.SalaryStatus = Convert.ToInt32(SalaryStatus.Pending);

                entity.isFullAndFinal = false;
                entity.CreatedBy = User.Identity.Name;
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedBy = User.Identity.Name;
                entity.ModifiedDate = DateTime.Now;
                return base.Create(entity);
            }
            else
                return HttpError();
        }

        [Authorize(Roles = "Accountant")]
        public override HttpResponseMessage Update(Salary entity)
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            int CurrentDay = DateTime.Now.Day;
            DateTime PreviousMonthDate = DateTime.Now.AddMonths(-1);
            int PreviousMonth = PreviousMonthDate.Month;
            int PreviousYear = PreviousMonthDate.Year;
            Model.Month objMonth = service.Context.Months.Where(m => m.MonthID == entity.MonthID).FirstOrDefault();
            if (objMonth != null && ((objMonth.Month1 == currentMonth && objMonth.Year == currentYear)
                || (objMonth.Month1 == PreviousMonth && objMonth.Year == PreviousYear && CurrentDay <= 5)))
            {
                entity.ModifiedBy = User.Identity.Name;
                entity.ModifiedDate = DateTime.Now;
                entity.Month = null;
                return base.Update(entity);
            }
            else
                return HttpError();
        }

        [HttpPost]
        [Authorize(Roles = "Accountant")]
        public HttpResponseMessage SendEmail(int employeeID, int monthID)
        {
            try
            {
                Salary objSalary = service.Context.Salaries.Where(m => m.EmployeeID == employeeID && m.MonthID == monthID).FirstOrDefault();
                DateTime dt = new DateTime(objSalary.Month.Year, objSalary.Month.Month1, 1);
                int salaryYear = dt.Year;
                string salaryMonth = dt.ToString("MMMM");

                string fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"];
                string fromEmailUser = ConfigurationManager.AppSettings["FromEmailUser"];
                string toEmailAdd = objSalary.Employee.Email;
                string toEmailUser = objSalary.Employee.FullName;
                string Subject = "Salary Slip for the month of " + salaryMonth + " " + salaryYear;
                var body = "Dear " + objSalary.Employee.FirstName + ",</br></br>";
                body = body + "PFA for the salary slip for the month of " + salaryMonth + " " + salaryYear + ".</br></br>";
                body = body + "Thanks & Regards,</br>Richa Nair</br>Practice Lead – HR</br>Alept Consulting Private LimitedPh: +91 7574853588 | URL: www.alept.com</br>B - 307/8/9, Mondeal Square, S.G.Highway Road, Prahladnagar, Ahmedabad, Gujarat - 380015";

                string attachment = Convert.ToBase64String(ExportToPdf(objSalary));
                bool isMailSent = Helper.SendEmailToEmployee(Subject, body, fromEmailAddress, fromEmailUser, toEmailAdd, toEmailUser, attachment);
                return HttpSuccess();
            }
            catch (Exception e)
            {
                return HttpError(e);
            }
        }

        [Authorize(Roles = "Accountant")]
        public byte[] ExportToPdf(Salary objSalary)
        {
            try
            {
                string pdfbody = string.Empty;

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SalaryPDFTemplate"])))
                {
                    pdfbody = reader.ReadToEnd();
                }

                pdfbody = pdfbody.Replace("{{LogoHeader}}", "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/File Formats/images/header.jpg");
                pdfbody = pdfbody.Replace("{{LogoFooter}}", "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/File Formats/images/footer.jpg");

                pdfbody = pdfbody.Replace("{{Name}}", objSalary.Employee.FullName);

                string month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(objSalary.Month.Month1);
                int year = (objSalary.Month.Year % 100);
                string salaryMonth = month + "-" + year;

                pdfbody = pdfbody.Replace("{{Month}}", salaryMonth);
                if (objSalary != null)
                {
                    if (objSalary.Total != null)
                    {
                        pdfbody = pdfbody.Replace("{{Total}}", objSalary.Total.Value.ToString("#,##0.00"));
                    }
                    else
                    {
                        pdfbody = pdfbody.Replace("{{Total}}", string.Empty);
                    }

                    if (objSalary.TotalPayment != null)
                    {
                        pdfbody = pdfbody.Replace("{{TotalPayment}}", objSalary.TotalPayment.Value.ToString("#,##0.00"));
                    }
                    else
                    {
                        pdfbody = pdfbody.Replace("{{TotalPayment}}", string.Empty);
                    }

                    if (!string.IsNullOrEmpty(objSalary.Note))
                    {
                        pdfbody = pdfbody.Replace("{{Note}}", objSalary.Note.ToString());
                    }
                    else
                    {
                        pdfbody = pdfbody.Replace("{{Note}}", string.Empty);
                    }

                    pdfbody = pdfbody.Replace("{{Days}}", objSalary.Days.ToString());
                    pdfbody = pdfbody.Replace("{{Basic}}", objSalary.Basic.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{HRA}}", objSalary.HRA.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{Conveyance Allowance}}", objSalary.ConveyanceAllowance.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{Other Allowance}}", objSalary.OtherAllowance.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{Medical re-imbursement}}", objSalary.MedicalReimbursement.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{Arrear Salary}}", objSalary.AdvanceSalary.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{Incentive}}", objSalary.Incentive.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{PLI}}", objSalary.PLI.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{Ex-gratia}}", objSalary.Exgratia.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{ReimbursementOfexp}}", objSalary.ReimbursementOfexp.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{TDS}}", objSalary.TDS.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{EPF}}", objSalary.EPF.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{Professional Tax}}", objSalary.ProfessionalTax.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{Salary}}", objSalary.Salary1.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{Leave}}", objSalary.Leave.ToString());
                    pdfbody = pdfbody.Replace("{{Advance}}", objSalary.Advance.ToString("#,##0.00"));
                    pdfbody = pdfbody.Replace("{{YTDS}}", objSalary.YTDS.ToString("#,##0.00"));
                }
                else
                {
                    pdfbody = pdfbody.Replace("{{Days}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Basic}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{HRA}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Conveyance Allowance}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Other Allowance}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Medical re-imbursement}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Arrear Salary}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Incentive}}", string.Empty);
                    pdfbody = pdfbody.Replace("{PLI}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Ex-gratia}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{ReimbursementOfexp}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{TDS}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{EPF}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Professional Tax}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Salary}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Leave}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{Advance}}", string.Empty);
                    pdfbody = pdfbody.Replace("{{YTDS}}", string.Empty);
                }

                byte[] pdfByte = Helper.CreatePDFFromHTMLFile(pdfbody);
                return pdfByte;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Authorize(Roles = "Accountant")]
        public HttpResponseMessage DownloadPDF(int EmpID, int MonthID)
        {
            Salary sObj = service.Get().Where(s => s.EmployeeID == EmpID && s.MonthID == MonthID).FirstOrDefault();
            List<Salary> salList = new List<Salary> { sObj };
            return Download(salList, false);
        }

        [HttpGet]
        [Authorize(Roles = "Accountant")]
        public HttpResponseMessage DownloadPDFZip(int MonthID)
        {
            List<Salary> approvedSalaryList = service.Get().Where(s => s.MonthID == MonthID && s.SalaryStatus == (int)Helper.SalaryStatus.Approved).ToList();
            List<Salary> approvedSalaryList1 = approvedSalaryList.Where(Helper.ignoreEmployeeStatus1).ToList();
            return Download(approvedSalaryList1, true);
        }

        [HttpPost]
        [Authorize(Roles = "Accountant")]
        public HttpResponseMessage SendAllEmail(int monthID)
        {
            try
            {
                List<Salary> objLstSalary = new List<Salary>();
                objLstSalary = service.Context.Salaries.Where(m => m.MonthID == monthID).ToList();
                Model.Month objMonth = service.Context.Months.Where(m => m.MonthID == monthID).FirstOrDefault();
                string salaryMonth = string.Empty;
                string salaryYear = string.Empty;
                if (objMonth != null)
                    salaryMonth = new DateTime(objMonth.Year, objMonth.Month1, 1).ToString("MMMM");

                if (objLstSalary != null && objLstSalary.Count > 0)
                {
                    foreach (var item in objLstSalary)
                    {
                        string fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"];
                        string fromEmailUser = ConfigurationManager.AppSettings["FromEmailUser"];
                        string toEmailAdd = "namrata.negi@alept.com";//item.Employee.Email;
                        string toEmailUser = item.Employee.FullName;
                        string Subject = "Salary Slip for the month of " + salaryMonth + " " + salaryYear;
                        var body = "Dear " + item.Employee.FirstName + ",</br></br>";
                        body = body + "PFA for the salary slip for the month of " + salaryMonth + " " + salaryYear + ".</br></br>";
                        body = body + "Thanks & Regards,</br>Richa Nair</br>Practice Lead – HR</br>Alept Consulting Private LimitedPh: +91 7574853588 | URL: www.alept.com</br>B - 307/8/9, Mondeal Square, S.G.Highway Road, Prahladnagar, Ahmedabad, Gujarat - 380015";

                        string attachment = Convert.ToBase64String(ExportToPdf(item));
                        bool isMailSent = Helper.SendEmailToEmployee(Subject, body, fromEmailAddress, fromEmailUser, toEmailAdd, toEmailUser, attachment);
                    }
                }


                return HttpSuccess();
            }
            catch (Exception e)
            {
                return HttpError(e);
            }
        }

        #region Private Methods
        private HttpResponseMessage Download(List<Salary> salList, bool isZip)
        {
            Byte[] ByteArray = null;
            string file = string.Empty;

            string month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(salList.FirstOrDefault().Month.Month1);
            int year = (salList.FirstOrDefault().Month.Year % 100);
            using (ZipFile zip = new ZipFile())
            {
                foreach (Salary salObj in salList)
                {
                    file = salObj.Employee.FullName + " - " + month + "-" + year + ".pdf";

                    ByteArray = ExportToPdf(salObj);
                    File.WriteAllBytes(file, ByteArray);

                    if (isZip)
                    {
                        zip.AlternateEncodingUsage = ZipOption.AsNecessary;
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

                    pushStreamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = string.Format("Salary Slip {0} {1}.zip", month, year),
                    };

                    return new HttpResponseMessage(HttpStatusCode.OK) { Content = pushStreamContent };
                }
            }

        }

        [Authorize(Roles = "Accountant")]
        private HttpResponseMessage InsertCSVRecords(DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {
                int month = Convert.ToInt32(row["Month"]);
                if (DateTime.Now.Month == month)
                {
                    string empCode = row["EmployeeCode"].ToString();
                    if (!string.IsNullOrEmpty(empCode))
                    {
                        int year = Convert.ToInt32(row["Year"]);
                        Employee emp = service.Context.Employees.Where(e => e.EmployeeCode.Equals(empCode)).FirstOrDefault();
                        if (emp != null)
                        {
                            int EmployeeID = emp.EmployeeID;
                            int MonthID = service.Context.Months.Where(m => m.Month1 == month && m.Year == year).FirstOrDefault().MonthID;
                            Salary sObj = service.Context.Salaries.Where(s => s.EmployeeID == EmployeeID && s.MonthID == MonthID).FirstOrDefault();
                            if (sObj == null)
                            {
                                InsertSalaryRecord(row, EmployeeID, MonthID);
                            }
                            else
                            {
                                UpdateSalaryRecord(row, sObj);
                            }
                        }
                        else
                        {
                            throw new Exception("There is no Employee for the provided Employee Code: " + empCode);
                        }
                    }
                    else
                    {
                        throw new Exception("Blank Employee Code is not allowed");
                    }
                }
                else
                {
                    throw new Exception("The CSV should contain records only for the month of " + DateTime.Now.ToString("MMMM"));
                }
            }
            service.SaveChanges();
            return HttpSuccess();


        }

        [Authorize(Roles = "Accountant")]
        private void InsertSalaryRecord(DataRow row, int EmployeeID, int MonthID)
        {
            Salary salaryObj = new Salary();
            salaryObj.EmployeeID = EmployeeID;
            salaryObj.MonthID = MonthID;

            salaryObj.Basic = Convert.ToDecimal(row["Basic"]);
            salaryObj.HRA = Convert.ToDecimal(row["HRA"]);
            salaryObj.ConveyanceAllowance = Convert.ToDecimal(row["ConveyanceAllowance"]);
            salaryObj.OtherAllowance = Convert.ToDecimal(row["OtherAllowance"]);
            salaryObj.MedicalReimbursement = Convert.ToDecimal(row["MedicalReimbursement"]);
            salaryObj.AdvanceSalary = Convert.ToDecimal(row["AdvanceSalary"]);
            salaryObj.Incentive = Convert.ToDecimal(row["Incentive"]);
            salaryObj.PLI = Convert.ToDecimal(row["PLI"]);
            salaryObj.Exgratia = Convert.ToDecimal(row["Exgratia"]);
            salaryObj.ReimbursementOfexp = Convert.ToDecimal(row["ReimbursementOfexp"]);
            salaryObj.TDS = Convert.ToDecimal(row["TDS"]);
            salaryObj.EPF = Convert.ToDecimal(row["EPF"]);
            salaryObj.ProfessionalTax = Convert.ToDecimal(row["ProfessionalTax"]);
            salaryObj.Leave = Convert.ToDecimal(row["Leave"]);
            salaryObj.Advance = Convert.ToDecimal(row["Advance"]);
            salaryObj.YTDS = Convert.ToDecimal(row["YTDS"]);
            salaryObj.Note = row["Note"].ToString();
            salaryObj.Salary1 = Convert.ToDecimal(row["Salary"]);
            salaryObj.Total = Convert.ToDecimal(row["Total"]);
            salaryObj.TotalPayment = Convert.ToDecimal(row["TotalPayment"]);
            salaryObj.Days = Convert.ToInt32(row["Days"]);
            salaryObj.AccountNumber = row["AccountNumber"].ToString();
            salaryObj.BankName = row["BankName"].ToString();
            salaryObj.SalaryStatus = (int)Helper.SalaryStatus.Pending;
            salaryObj.CreatedBy = row["CreatedBy"].ToString();
            salaryObj.ModifiedBy = row["ModifiedBy"].ToString();
            salaryObj.CreatedDate = row["CreatedDate"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(row["CreatedDate"]);
            salaryObj.ModifiedDate = row["ModifiedDate"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(row["ModifiedDate"]);
            service.Context.Salaries.Add(salaryObj);
        }

        [Authorize(Roles = "Accountant")]
        private void UpdateSalaryRecord(DataRow row, Salary salaryObj)
        {
            salaryObj.Basic = Convert.ToDecimal(row["Basic"]);
            salaryObj.HRA = Convert.ToDecimal(row["HRA"]);
            salaryObj.ConveyanceAllowance = Convert.ToDecimal(row["ConveyanceAllowance"]);
            salaryObj.OtherAllowance = Convert.ToDecimal(row["OtherAllowance"]);
            salaryObj.MedicalReimbursement = Convert.ToDecimal(row["MedicalReimbursement"]);
            salaryObj.AdvanceSalary = Convert.ToDecimal(row["AdvanceSalary"]);
            salaryObj.Incentive = Convert.ToDecimal(row["Incentive"]);
            salaryObj.PLI = Convert.ToDecimal(row["PLI"]);
            salaryObj.Exgratia = Convert.ToDecimal(row["Exgratia"]);
            salaryObj.ReimbursementOfexp = Convert.ToDecimal(row["ReimbursementOfexp"]);
            salaryObj.TDS = Convert.ToDecimal(row["TDS"]);
            salaryObj.EPF = Convert.ToDecimal(row["EPF"]);
            salaryObj.ProfessionalTax = Convert.ToDecimal(row["ProfessionalTax"]);
            salaryObj.Leave = Convert.ToDecimal(row["Leave"]);
            salaryObj.Advance = Convert.ToDecimal(row["Advance"]);
            salaryObj.YTDS = Convert.ToDecimal(row["YTDS"]);
            salaryObj.Note = row["Note"].ToString();
            salaryObj.Salary1 = Convert.ToDecimal(row["Salary"]);
            salaryObj.Total = Convert.ToDecimal(row["Total"]);
            salaryObj.TotalPayment = Convert.ToDecimal(row["TotalPayment"]);
            salaryObj.Days = Convert.ToInt32(row["Days"]);
            salaryObj.AccountNumber = row["AccountNumber"].ToString();
            salaryObj.BankName = row["BankName"].ToString();
            salaryObj.SalaryStatus = (int)Helper.SalaryStatus.Pending;
            salaryObj.CreatedBy = row["CreatedBy"].ToString();
            salaryObj.ModifiedBy = row["ModifiedBy"].ToString();
            salaryObj.CreatedDate = row["CreatedDate"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(row["CreatedDate"]);
            salaryObj.ModifiedDate = row["ModifiedDate"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(row["ModifiedDate"]);
        }
        #endregion

    }
}