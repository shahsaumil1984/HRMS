using Api;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                                o.EmployeeStatusID

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
                                EmployeeStatusID = o.EmployeeStatusID

                            }).Single<Employee>();
            return obj;
        }

        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<Employee> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = from o in list
                        where o.EmployeeStatusID != 4
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
                            o.EmployeeStatusID
                        };

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }

    }
}