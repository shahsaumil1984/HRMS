

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Service;
using Model;
using Microsoft.AspNet.Identity;
using HRMS;

namespace Api
{
    public class EmployeeController : GenericApiController<EmployeeService, Employee, int>, IGetList
    {
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
                                o.SalaryAccountIFSCCode

                            }).ToList().Select(o => new Employee
                            {
                                EmployeeID = o.EmployeeID,
                                FirstName = o.FirstName,
                                LastName = o.LastName,
                                FullName = o.FullName,
                                PermanentAddressLine1 = o.PermanentAddressLine1,
                                PermanentAddressLine2 = o.PermanentAddressLine2,
                                PermanentAddressLine3 = o.PermanentAddressLine3,
                                PermanentAddressState = o.PermanentAddressState,
                                PermanentAddressCountry = o.PermanentAddressCountry,
                                PermanentAddressZip = o.PermanentAddressZip,
                                AddressLine1 = o.AddressLine1,
                                AddressLine2 = o.AddressLine2,
                                AddressLine3 = o.AddressLine3,
                                AddressState = o.AddressState,
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
                                SalaryAccountIFSCCode = o.SalaryAccountIFSCCode
                            }).Single<Employee>();
            return obj;
        }

        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<Employee> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = from o in list
                        select new
                        {

                            o.EmployeeID,
                            o.FirstName,
                            o.LastName,
                            o.FullName,
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
                            o.SalaryAccountIFSCCode
                        };

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }

        public override HttpResponseMessage Create(Employee entity)
        {
            HttpResponseMessage obj = base.Create(entity);
            var user = new ApplicationUser { UserName = entity.FirstName, Email = "", EmailConfirmed = true, EmployeeId = entity.EmployeeID, FirstName = entity.FirstName, LastName = entity.LastName, PhoneNumber = "" };            

            return obj;   
        }

        public override HttpResponseMessage Update(Employee entity)
        {
            return base.Update(entity); 
        }
    }
}

