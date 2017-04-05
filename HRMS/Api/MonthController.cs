using Model;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Api;
using Model;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Globalization;

namespace HRMS.Api
{
    public class MonthController : GenericApiController<MonthService, Month, int>, IGetList
    {
        public override object GetModel()
        {
            Month obj = (Month)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        public override Month GetById(int id)
        {
            Month obj = (from o in service.Context.Months
                         where o.MonthID == id
                         select new
                         {
                             o.Month1,
                             o.Year
                         }).ToList().Select(o => new Month
                         {
                             Month1 = o.Month1,
                             Year = o.Year
                         }).Single<Month>();
            return obj;
        }
        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            string CurrentMonth = DateTime.Today.ToString("MMMM");
            int currentMonthID = service.Get().Where(m => m.Month1 == CurrentMonth && m.Year == DateTime.Now.Year).FirstOrDefault().MonthID;
            if (string.IsNullOrEmpty(filter))
            {
                filter = "MonthID <= " + currentMonthID;

            }
            else
            {
                filter += "and MonthID <= " + currentMonthID;
            }

            //
            IQueryable<Month> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = from o in list
                            //where o.MonthID <= currentMonthID                      
                            //orderby o.MonthID ascending
                        select new
                        {
                            o.MonthID,
                            o.Month1,
                            o.Year
                        };

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }

        public HttpResponseMessage GetGenerateandDownloadCSV(int MonthID)
        {
            //Create CSV file            
            var csv = new StringBuilder();
            EmployeeService empService = new EmployeeService();


            var newLine = string.Format("{0},{1},{2},{3}", "EmployeeCode", "Salary", "Credit", "Note");
            csv.AppendLine(newLine);

            var EmpList = empService.Get().Where(e => e.EmployeeStatusID == (int)Helper.EmployeeStatus.Active);
            
            foreach (var emp in EmpList)
            {
                if (emp.Salaries.FirstOrDefault() != null && emp.Salaries.FirstOrDefault().SalaryStatus == Helper.SalaryStatus.Approve.ToString())
                {
                    var empCode = emp.EmployeeCode;
                    var salary = emp.Salaries.FirstOrDefault() == null ? 0 : emp.Salaries.FirstOrDefault().Salary1;
                    var desc = "Cr";
                    var note = emp.Salaries.FirstOrDefault() == null ? "" : emp.Salaries.FirstOrDefault().Note;

                    newLine = string.Format("{0},{1},{2},{3}", empCode, salary, desc, note);
                    csv.AppendLine(newLine);
                }

            }

            MonthService mservice = new MonthService();
            Month monthObj = mservice.GetById(MonthID);
            string fileName = "ALE57SAL" + DateTime.Now.Day.ToString("00") + DateTime.ParseExact(monthObj.Month1, "MMMM", CultureInfo.InvariantCulture).Month.ToString("00") + ".001.csv";            

            File.WriteAllText(fileName, csv.ToString());

            //Download CSV file
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };

            return response;

        }
    }
}