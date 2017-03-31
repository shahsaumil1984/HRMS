using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Api
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
            int currentMonthID = service.Get().Where(m => m.Month1 == CurrentMonth && m.Year == DateTime.Now.Year.ToString()).FirstOrDefault().MonthID;
            if (string.IsNullOrEmpty(filter))
            {
                filter = "MonthID <= " + currentMonthID;

            }
            else {
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

        public void GenerateandDownloadCSV()
        {
            //Create CSV file            
            var csv = new StringBuilder();
            EmployeeService empService = new EmployeeService();
            var EmpList = empService.Get(e => e.EmployeeStatusID == 1);

            //foreach (var emp in EmpList)
            //{

            //}
            ////in your loop
            //var first = reader[0].ToString();
            //var second = image.ToString();
            ////Suggestion made by KyleMit
            //var newLine = string.Format("{0},{1}", first, second);
            //csv.AppendLine(newLine);

            ////after your loop
            //File.WriteAllText(filePath, csv.ToString());


            ////Download CSV file
            //string filePath = "~/Files/Sample.csv";
            //System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(filePath));
            //if (file.Exists)
            //{
            //    Response.ContentType = "text/csv";
            //    Response.AppendHeader("Content-Disposition", "Attachment; Filename=" + file.Name + "");
            //    Response.TransmitFile(Server.MapPath(filePath));
            //    Response.End();
            //}
        }
    }
}