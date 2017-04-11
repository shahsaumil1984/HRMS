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

namespace Api
{
    public class SalaryController : GenericApiController<SalaryService, Salary, int>, IGetList
    {
        //// GET: Salary
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public override object GetModel()
        {
            Salary obj = (Salary)base.GetModel();

            // Set Default Values Here

            return obj;
        }

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
                              o.BankName

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
                              BankName = o.BankName

                          }).Single<Salary>();
            return obj;
        }

        [HttpPost]
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
                                 o.SalaryStatus,
                                 o.BankName,
                                 o.AccountNumber,
                                 o.Employee.FullName,
                                 o.Employee.EmployeeCode
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
                SalaryStatus = o.SalaryStatus,
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
                    obj = new Salary() { EmployeeID = employeeID, MonthID = monthID };
                }
            }
            return obj;
        }

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

        [HttpGet]
        public HttpResponseMessage GenerateandDownloadPDF(int EmployeeID, int MonthID)
        {
            try
            {
                EmployeeService eService = new EmployeeService();
                string employeeCode = eService.Get().Where(e => e.EmployeeID == EmployeeID).FirstOrDefault().EmployeeCode;
                MonthService mService = new MonthService();
                string month = Enum.GetName(typeof(Helper.Month), mService.GetById(MonthID).Month1);               

                SalaryService sService = new SalaryService();
                Salary sObj = sService.Get().Where(s => s.EmployeeID == EmployeeID && s.MonthID == MonthID).FirstOrDefault();

                string sourceFile = HttpContext.Current.Server.MapPath(@"~\File Formats\Letter head.docx");
                string targetFile = HttpContext.Current.Server.MapPath(@"~\File Formats\SalarySlip_" + employeeCode + month + ".docx");
                File.Copy(sourceFile, targetFile, true);


                string fileName = Path.GetFileName(targetFile);
                ///Download PDF file
                var stream = new FileStream(targetFile, FileMode.Open, FileAccess.Read);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };

                return response;

                //return HttpSuccess();
            }
            catch (Exception e)
            {
                return HttpError(e);
            }

        }

        public override HttpResponseMessage Create(Salary entity)
        {
            return base.Create(entity);
        }

        #region Private Methods
        private HttpResponseMessage InsertCSVRecords(DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {
                string month = row["Month"].ToString();
                if (DateTime.Now.ToString("MMMM").Equals(month))
                {
                    string empCode = row["EmployeeCode"].ToString();
                    if (!string.IsNullOrEmpty(empCode))
                    {
                        int year = Convert.ToInt32(row["Year"]);
                        Employee emp = service.Context.Employees.Where(e => e.EmployeeCode.Equals(empCode)).FirstOrDefault();
                        if (emp != null)
                        {
                            int EmployeeID = emp.EmployeeID;
                            int MonthID = service.Context.Months.Where(m => m.Month1.Equals(month) && m.Year == year).FirstOrDefault().MonthID;
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