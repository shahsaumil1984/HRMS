
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Model;
using System.Linq.Dynamic;
namespace Service
{
    public class EmployeeService : GenericService<Employee, int>
    {
        public override void Create(Employee entity)
        {
            //entity.ModifiedDate = DateTime.Today;
            //entity.CreatedDate = DateTime.Today;
            base.Create(entity);
        }

        public override void Update(Employee entity)
        {
            //entity.ModifiedDate = DateTime.Today;
            base.Update(entity);
        }

        public override bool Validate(Employee entity)
        {
            // throw ValidationException when an error occurs

            return true;
        }
        public virtual IQueryable<Employee> GetEmpSalary(int? pageIndex, int? pageSize, string filter, string orderBy, string includeProperties = "")
        {


            IQueryable<Employee> query = this.Context.Set<Employee>();






            IQueryable<Employee> empQuery;

            string SalaryStatusPending = "Pending";
            int SalaryStatusPendingID = 1;
            string SalaryStatusApproved = "Approved";
            int SalaryStatusApprovedID = 2;


            //string ActualStatusFilter;



            var myQuery = (from m in Context.Employees
                           join sal in Context.Salaries on m.EmployeeID equals sal.EmployeeID into Es
                           from EmpSal in Es.DefaultIfEmpty()

                           select new
                           {
                               EmployeeID = m.EmployeeID,
                               EmployeeCode = m.EmployeeCode,
                               FirstName = m.FirstName,
                               LastName = m.LastName,
                               FullName = m.FullName,
                               Email = m.Email,
                               Phone = m.Phone,
                               PermanentAddressLine1 = m.PermanentAddressLine1,
                               PermanentAddressLine2 = m.PermanentAddressLine2,
                               PermanentAddressLine3 = m.PermanentAddressLine3,
                               PermanentAddressState = m.PermanentAddressState,
                               PermanentAddressCountry = m.PermanentAddressCountry,
                               PermanentAddressZip = m.PermanentAddressZip,
                               AddressLine1 = m.AddressLine1,
                               AddressLine2 = m.AddressLine2,
                               AddressLine3 = m.AddressLine3,
                               AddressState = m.AddressState,
                               AddressCountry = m.AddressCountry,
                               AddressZip = m.AddressZip,
                               DateOfBirth = m.DateOfBirth,
                               DateOfjoining = m.DateOfjoining,
                               ProbationPeriodEndDate = m.ProbationPeriodEndDate,
                               HasResigned = m.HasResigned,
                               DateOfResignation = m.DateOfResignation,
                               LastWorkingDay = m.LastWorkingDay,
                               PAN = m.PAN,
                               IDCardNumber = m.IDCardNumber,
                               IDCardType = m.IDCardType,
                               SalaryAccountNumber = m.SalaryAccountNumber,
                               SalaryAccountBank = m.SalaryAccountBank,
                               SalaryAccountBankAddress = m.SalaryAccountBankAddress,
                               SalaryAccountIFSCCode = m.SalaryAccountIFSCCode,
                               AddressCity = m.AddressCity,
                               PermanentAddressCity = m.PermanentAddressCity,



                               EmployeePhoto = m.EmployeePhoto,
                               SalaryStatus = EmpSal != null ? EmpSal.SalaryStatus : SalaryStatusPendingID,
                               MonthID = EmpSal != null ? EmpSal.MonthID : 0,
                               SalaryStatusText = EmpSal != null ? EmpSal.SalaryStatu.SalaryStatusName : SalaryStatusPending
                           }).AsQueryable();

            filter = filter.Replace("MonthID", "( MonthID = 0 OR MonthID") + ")";

            //myQuery = myQuery.Where(EmpSal => EmpSal.MonthID == 0 || EmpSal.MonthID == 436);
            //var salary = Context.Salaries
            var q1 = myQuery.Where(filter);

            _totalRowCount = q1.Count();
            if (orderBy != null && orderBy != string.Empty && orderBy != "null")
            {
                q1 = q1.OrderBy(orderBy);
            }

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                q1 = q1.Skip((int)pageIndex * (int)pageSize).Take((int)pageSize);
            }

            empQuery = q1.ToList().Select(m => new
           Employee
            {
                EmployeeID = m.EmployeeID,
                EmployeeCode = m.EmployeeCode,
                FirstName = m.FirstName,
                LastName = m.LastName,
                FullName = m.FullName,
                Email = m.Email,
                Phone = m.Phone,
                PermanentAddressLine1 = m.PermanentAddressLine1,
                PermanentAddressLine2 = m.PermanentAddressLine2,
                PermanentAddressLine3 = m.PermanentAddressLine3,
                PermanentAddressState = m.PermanentAddressState,
                PermanentAddressCountry = m.PermanentAddressCountry,
                PermanentAddressZip = m.PermanentAddressZip,
                AddressLine1 = m.AddressLine1,
                AddressLine2 = m.AddressLine2,
                AddressLine3 = m.AddressLine3,
                AddressState = m.AddressState,
                AddressCountry = m.AddressCountry,
                AddressZip = m.AddressZip,
                DateOfBirth = m.DateOfBirth,
                DateOfjoining = m.DateOfjoining,
                ProbationPeriodEndDate = m.ProbationPeriodEndDate,
                HasResigned = m.HasResigned,
                DateOfResignation = m.DateOfResignation,
                LastWorkingDay = m.LastWorkingDay,
                PAN = m.PAN,
                IDCardNumber = m.IDCardNumber,
                IDCardType = m.IDCardType,
                SalaryAccountNumber = m.SalaryAccountNumber,
                SalaryAccountBank = m.SalaryAccountBank,
                SalaryAccountBankAddress = m.SalaryAccountBankAddress,
                SalaryAccountIFSCCode = m.SalaryAccountIFSCCode,
                AddressCity = m.AddressCity,
                PermanentAddressCity = m.PermanentAddressCity,
                EmployeePhoto = m.EmployeePhoto,
                Salaries = new List<Salary>() { new Salary() { SalaryStatus = m.SalaryStatus, SalaryStatu = new SalaryStatu() { SalaryStatusName = m.SalaryStatusText } } }
            }).AsQueryable();
            return empQuery;


        }

    }
}
