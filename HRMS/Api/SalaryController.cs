using HRMS;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Net;
using System.Net.Http.Headers;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Globalization;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using static HRMS.Helper;
using Ionic.Zip;

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
                              o.SalaryStatusName

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
                              SalaryStatusName = o.SalaryStatusName
                          }).Single<Salary>();
            return obj;
        }

        [HttpPost]
        [Authorize(Roles = "Accountant")]
        public Salary GetByMonth(int employeeID, int monthID, bool CheckPrevious = true)
        {
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
                                 o.SalaryStatu.SalaryStatusName,
                                 o.BankName,
                                 o.AccountNumber,
                                 o.Employee.FullName
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
                SalaryStatusName = o.SalaryStatusName,
                BankName = o.BankName,
                AccountNumber = o.AccountNumber,
                Note = o.Note
            }).SingleOrDefault<Salary>();

            if (obj == null)
            {
                if (CheckPrevious)
                {
                    var newMonthID = monthID/*Set new month id*/;
                    obj = GetByMonth(employeeID, monthID, false);
                    obj.MonthID = monthID;
                }
                else
                {
                    obj = new Salary() { EmployeeID = employeeID, MonthID = monthID, SalaryStatusName = Helper.SalaryStatus.Pending.ToString() };
                }
            }
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

                //Creating columns
                tblcsv.Columns.Add("EmployeeCode");
                tblcsv.Columns.Add("Year");
                tblcsv.Columns.Add("Month");

                tblcsv.Columns.Add("Basic");
                tblcsv.Columns.Add("HRA");
                tblcsv.Columns.Add("ConveyanceAllowance");
                tblcsv.Columns.Add("OtherAllowance");
                tblcsv.Columns.Add("MedicalReimbursement");
                tblcsv.Columns.Add("AdvanceSalary");
                tblcsv.Columns.Add("Incentive");
                tblcsv.Columns.Add("PLI");
                tblcsv.Columns.Add("Exgratia");
                tblcsv.Columns.Add("ReimbursementOfexp");
                tblcsv.Columns.Add("TDS");
                tblcsv.Columns.Add("EPF");
                tblcsv.Columns.Add("ProfessionalTax");
                tblcsv.Columns.Add("Leave");
                tblcsv.Columns.Add("Advance");
                tblcsv.Columns.Add("YTDS");
                tblcsv.Columns.Add("Note");
                tblcsv.Columns.Add("Salary");
                tblcsv.Columns.Add("Total");
                tblcsv.Columns.Add("TotalPayment");
                tblcsv.Columns.Add("Days");
                tblcsv.Columns.Add("AccountNumber");
                tblcsv.Columns.Add("BankName");
                tblcsv.Columns.Add("CreatedBy");
                tblcsv.Columns.Add("ModifiedBy");
                tblcsv.Columns.Add("CreatedDate");
                tblcsv.Columns.Add("ModifiedDate");

                //string CSVFilePath = Path.GetFullPath(filePath);

                //Reading All text  
                string ReadCSV = string.Empty;

                using (var reader = new StreamReader(httpPostedFile.InputStream, Encoding.UTF8))
                {
                    ReadCSV = reader.ReadToEnd();
                }

                //spliting row after new line  
                foreach (string csvRow in ReadCSV.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(csvRow))
                    {
                        //Adding each row into datatable  
                        tblcsv.Rows.Add();
                        int count = 0;
                        foreach (string FileRec in csvRow.Split(','))
                        {
                            tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                            count++;
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
            if (entity.SalaryStatusName == SalaryStatus.Approved.ToString())
                entity.SalaryStatus = Convert.ToInt32(SalaryStatus.Approved);
            else
                entity.SalaryStatus = Convert.ToInt32(SalaryStatus.Pending);
            return base.Create(entity);
        }

        [HttpPost]
        [Authorize(Roles = "Accountant")]
        public HttpResponseMessage SendEmail(int employeeID, int monthID)
        {
            try
            {
                Employee objEmployee = service.Context.Employees.Where(m => m.EmployeeID == employeeID).FirstOrDefault();
                Salary objSalary = service.Context.Salaries.Where(m => m.EmployeeID == employeeID && m.MonthID == monthID).FirstOrDefault();
                Model.Month objMonth = service.Context.Months.Where(m => m.MonthID == monthID).FirstOrDefault();
                string salaryMonth = string.Empty;
                string salaryYear = string.Empty;
                if (objMonth != null)
                    salaryMonth = new DateTime(objMonth.Year, objMonth.Month1, 1).ToString("MMMM");

                string fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"];
                string fromEmailUser = ConfigurationManager.AppSettings["FromEmailUser"];
                string toEmailAdd = "namrata.negi@alept.com";//objEmployee.Email;
                string toEmailUser = objEmployee.FullName;
                string Subject = "Salary Slip for the month of " + salaryMonth + " " + salaryYear;
                var body = "Dear " + objEmployee.FirstName + ",</br></br>";
                body = body + "PFA for the salary slip for the month of " + salaryMonth + " " + salaryYear + ".</br></br>";
                body = body + "Thanks & Regards,</br>Richa Nair</br>Practice Lead – HR</br>Alept Consulting Private LimitedPh: +91 7574853588 | URL: www.alept.com</br>B - 307/8/9, Mondeal Square, S.G.Highway Road, Prahladnagar, Ahmedabad, Gujarat - 380015";

                string attachment = ExportToPdf(objSalary, objEmployee.FullName, salaryMonth);
                bool isMailSent = Helper.SendEmailToEmployee(Subject, body, fromEmailAddress, fromEmailUser, toEmailAdd, toEmailUser, attachment);
                return HttpSuccess();
            }
            catch (Exception e)
            {
                return HttpError(e);
            }
        }

        [Authorize(Roles = "Accountant")]
        public string ExportToPdf(Salary objSalary, string employeeName, string month)
        {
            string result = string.Empty;

            try
            {
                
                //var array = File.ReadAllBytes("E:\\New Text Document.txt");
                //string data = Convert.ToBase64String(array);

                string pdfbody = string.Empty;

                using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SalaryPDFTemplate"])))
                {
                    pdfbody = reader.ReadToEnd();
                }

                pdfbody = pdfbody.Replace("{{LogoHeader}}", "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/File Formats/images/header.jpg");
                pdfbody = pdfbody.Replace("{{LogoFooter}}", "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/File Formats/images/footer.jpg");

                pdfbody = pdfbody.Replace("{{Name}}", employeeName);
                pdfbody = pdfbody.Replace("{{Month}}", month);
                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Days}}", objSalary.Days.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Days}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Basic}}", objSalary.Basic.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Basic}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{HRA}}", objSalary.HRA.ToString());
                else
                    pdfbody = pdfbody.Replace("{{HRA}}", string.Empty);
                
                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Conveyance Allowance}}", objSalary.ConveyanceAllowance.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Conveyance Allowance}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Other Allowance}}", objSalary.OtherAllowance.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Other Allowance}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Medical re-imbursement}}", objSalary.MedicalReimbursement.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Medical re-imbursement}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Arrear Salary}}", objSalary.AdvanceSalary.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Arrear Salary}}", string.Empty);
                
                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Incentive}}", objSalary.Incentive.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Incentive}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{PLI}}", objSalary.PLI.ToString());
                else
                    pdfbody = pdfbody.Replace("{PLI}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Ex-gratia}}", objSalary.Exgratia.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Ex-gratia}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{ReimbursementOfexp}}", objSalary.ReimbursementOfexp.ToString());
                else
                    pdfbody = pdfbody.Replace("{{ReimbursementOfexp}}", string.Empty);

                if (objSalary != null && objSalary.Total != null)
                    pdfbody = pdfbody.Replace("{{Total}}", objSalary.Total.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Total}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{TDS}}", objSalary.TDS.ToString());
                else
                    pdfbody = pdfbody.Replace("{{TDS}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{EPF}}", objSalary.EPF.ToString());
                else
                    pdfbody = pdfbody.Replace("{{EPF}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Professional Tax}}", objSalary.ProfessionalTax.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Professional Tax}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Leave}}", objSalary.Leave.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Leave}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Advance}}", objSalary.Advance.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Advance}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{Salary}}", objSalary.Salary1.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Salary}}", string.Empty);

                if (objSalary != null && objSalary.TotalPayment != null)
                    pdfbody = pdfbody.Replace("{{TotalPayment}}", objSalary.TotalPayment.ToString());
                else
                    pdfbody = pdfbody.Replace("{{TotalPayment}}", string.Empty);

                if (objSalary != null)
                    pdfbody = pdfbody.Replace("{{YTDS}}", objSalary.YTDS.ToString());
                else
                    pdfbody = pdfbody.Replace("{{YTDS}}", string.Empty);

                if (objSalary != null && !string.IsNullOrEmpty(objSalary.Note))
                    pdfbody = pdfbody.Replace("{{Note}}", objSalary.Note.ToString());
                else
                    pdfbody = pdfbody.Replace("{{Note}}", string.Empty);
                byte[] pdfByte = Helper.CreatePDFFromHTMLFile(pdfbody);

                File.WriteAllBytes("E://Foo.pdf", pdfByte);
                result = Convert.ToBase64String(pdfByte);



                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

    

        #region Private Methods
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