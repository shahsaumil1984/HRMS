using Api;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace HRMS.Api
{
    public class EmployeeStatusHistoryExtendController  : GenericApiController<EmployeeStatusHistoryExtendService, EmployeeStatusHistoryExtend, int>
    {
        
        HRMSEntities dbContext = new HRMSEntities();
        AspNetUserService aspNetUserService = new AspNetUserService();
        
        public override object GetModel()
        {
            EmployeeStatusHistoryExtend obj = (EmployeeStatusHistoryExtend)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        
        public override EmployeeStatusHistoryExtend GetById(int id)
        {
            service.Context.Configuration.ProxyCreationEnabled = false;

            var data = dbContext.EmployeeStatusHistories.Where(i => i.EmployeeID == id).OrderByDescending(i=>i.EmployeeStatusID).First();
            int monthid = Convert.ToInt32(service.Context.Months.Where(x => x.Month1 == DateTime.Now.Month && x.Year == DateTime.Now.Year).Select(x => x.MonthID).FirstOrDefault());
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            EmployeeStatusHistoryExtend obj = new EmployeeStatusHistoryExtend();

            obj.CreatedBy = data.CreatedBy;
            obj.CreatedDate = data.CreatedDate;
            obj.EmployeeID = data.EmployeeID;
            obj.EmployeeStatusID = data.EmployeeStatusID;
            obj.CurrentStatus= data.EmployeeStatu.Status;
            obj.StartDate = data.StartDate;
            obj.EndDate = data.EndDate;
            obj.StatusNote = data.StatusNote;
            obj.NewStatusID = data.NewStatusID;
            obj.Employee = new Employee();
            obj.Employee.FullName = data.Employee.FullName;
            obj.Employee.SalaryAccountBank = data.Employee.SalaryAccountBank;
            obj.Employee.SalaryAccountNumber = data.Employee.SalaryAccountNumber;
            obj.Employee.EmployeeCode = data.Employee.EmployeeCode;
            obj.Employee.Salaries = new List<Salary>();
            obj.Employee.Salaries.Add(new Salary
            {                                              
                AccountNumber = data.Employee.SalaryAccountNumber,
                Advance = 0,
                AdvanceSalary = 0,
                BankName = data.Employee.SalaryAccountBank,
                Basic = 0,
                ConveyanceAllowance = 0,
                CreatedBy = HttpContext.Current.User.Identity.Name,
                CreatedDate = Convert.ToDateTime(DateTime.Now),
                Days = daysInMonth,
                EmployeeID = data.EmployeeID,
                EPF = 0,
                Exgratia = 0,
                HRA = 0,
                Incentive = 0,
                Leave = 0,
                MedicalReimbursement = 0,
                ModifiedBy = HttpContext.Current.User.Identity.Name,
                ModifiedDate = Convert.ToDateTime(DateTime.Now),
                MonthID = monthid,
                Note = "",
                OtherAllowance = 0,
                PLI = 0,
                ProfessionalTax = 0,
                ReimbursementOfexp = 0,
                TDS = 0, 
                Total = 0,
                TotalPayment = 0,
                YTDS = 0,
                isFullAndFinal = true,
                SalaryStatus = Convert.ToInt32(Helper.SalaryStatus.Approved)               
            });
            return obj;
        }

        public override HttpResponseMessage Update(EmployeeStatusHistoryExtend entity)
        {
            
            entity.ModifiedBy = User.Identity.Name;
            entity.CreatedBy = User.Identity.Name;

            service.Update(entity);
            return HttpSuccess(); //base.Update(entity); 
        }
        public override HttpResponseMessage Create(EmployeeStatusHistoryExtend entity)
        {
            AspNetUser objAspNetUser = aspNetUserService.Get().Where(m => m.EmployeeId == entity.EmployeeID).FirstOrDefault();
            entity.ModifiedBy = objAspNetUser.Email;
            entity.CreatedBy = objAspNetUser.Email;
            return base.Create(entity);

        }
    }
}