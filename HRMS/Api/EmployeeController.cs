
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Service;
using Model;
using HRMS;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using WebTest.Models;

namespace Api
{
    public class EmployeeController : GenericApiController<EmployeeService, Employee, int>, IGetList
    {
        private ApplicationUserManager _userManager;
        static Random r = new Random();

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize(Roles = "Admin")]
        public override object GetModel()
        {
            Employee obj = (Employee)base.GetModel();
            // Set Default Values Here

            return obj;
        }

        [Authorize(Roles = "Admin")]
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
                                o.EmployeeStatusID,
                                o.EmployeeCode

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
                                EmployeeStatusID = o.EmployeeStatusID,
                                EmployeeCode = o.EmployeeCode

                            }).Single<Employee>();
            return obj;
        }

        [Authorize(Roles = "Admin")]
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
                            o.EmployeeCode
                        };

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }

        [Authorize(Roles = "Admin")]
        public override HttpResponseMessage Create(Employee entity)
        {
            // Set Probation Status of Employee, when Create user ID = 1 for Probation
            entity.EmployeeStatusID = (int)Helper.EmployeeStatus.Probation ;
            HttpResponseMessage obj = base.Create(entity);

            
            EmployeeStatusHistoryService ehService = new EmployeeStatusHistoryService();

            EmployeeStatusHistory employeeStatusHistory = new EmployeeStatusHistory()
            {
                
                NewStatusID = (int)Helper.EmployeeStatus.Probation,
                EmployeeID = entity.EmployeeID,
                StartDate = entity.DateOfjoining,
                EndDate = entity.ProbationPeriodEndDate,
                StatusNote = "This is Default Status of Employee",
                CreatedBy = User.Identity.Name,
            };

            ehService.Create(employeeStatusHistory);
            ehService.SaveChanges();

            var user = new HRMS.ApplicationUser
            {
                UserName = entity.Email,
                Email = entity.Email,
                EmailConfirmed = true,
                EmployeeId = entity.EmployeeID,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = ""
            };
            string newPassword = GenerateStrongPassword(10);
            IdentityResult result = UserManager.Create(user, newPassword);
            if (result.Succeeded)
            {
                AspNetUserService aspNetUserService = new AspNetUserService();
                AspNetUser objAspNetUser = aspNetUserService.Get().Where(m => m.EmployeeId == entity.EmployeeID).FirstOrDefault();
                if (objAspNetUser != null)
                {
                    string userId = objAspNetUser.Id;
                    if (!string.IsNullOrEmpty(userId))
                    {
                        string RoleID = service.Context.AspNetRoles.Where(x => x.Name == "Employee").FirstOrDefault().Name;
                        UserManager.AddToRole(userId, RoleID);
                    }
                }
            }
            return obj;
        }

        [Authorize(Roles = "Admin")]
        public static string GenerateStrongPassword(int length)
        {
            string alphaCaps = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string alphaLow = "qwertyuiopasdfghjklzxcvbnm";
            string numerics = "1234567890";
            string special = "@#$";
            //create another string which is a concatenation of all above
            string allChars = alphaCaps + alphaLow + numerics + special;


            string generatedPassword = "";


            int pLower, pUpper, pNumber, pSpecial;
            string posArray = "0123456789";
            if (length < posArray.Length)
                posArray = posArray.Substring(0, length);
            pLower = getRandomPosition(ref posArray);
            pUpper = getRandomPosition(ref posArray);
            pNumber = getRandomPosition(ref posArray);
            pSpecial = getRandomPosition(ref posArray);


            for (int i = 0; i < length; i++)
            {
                if (i == pLower)
                    generatedPassword += getRandomChar(alphaCaps);
                else if (i == pUpper)
                    generatedPassword += getRandomChar(alphaLow);
                else if (i == pNumber)
                    generatedPassword += getRandomChar(numerics);
                else if (i == pSpecial)
                    generatedPassword += getRandomChar(special);
                else
                    generatedPassword += getRandomChar(allChars);
            }
            return generatedPassword;
        }

        [Authorize(Roles = "Admin")]
        private static string getRandomChar(string fullString)
        {
            return fullString.ToCharArray()[(int)Math.Floor(r.NextDouble() * fullString.Length)].ToString();
        }

        [Authorize(Roles = "Admin")]
        private static int getRandomPosition(ref string posArray)
        {
            int pos;
            string randomChar = posArray.ToCharArray()[(int)Math.Floor(r.NextDouble()
                                           * posArray.Length)].ToString();
            pos = int.Parse(randomChar);
            posArray = posArray.Replace(randomChar, "");
            return pos;
        }

        [Authorize(Roles = "Admin")]
        public override HttpResponseMessage Update(Employee entity)
        {
            return base.Update(entity);
        }

        [Authorize(Roles = "Admin")]
        public bool GetCheckEmployeeCode(int EmpCode)
        {
            return service.Context.Employees.ToList().Any(e => e.EmployeeCode.Equals(EmpCode.ToString()));            
        }

    }





}

