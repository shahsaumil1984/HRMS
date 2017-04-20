using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Microsoft;

namespace Service
{
    public class EmployeeStatusHistoryExtendService: GenericService<Model.EmployeeStatusHistoryExtend, int>
    {
        public override void Update(EmployeeStatusHistoryExtend entity)
        {
            try
            {
                EmployeeStatusHistoryService serviceHistory = new EmployeeStatusHistoryService();

                var _employee = serviceHistory.Context.Employees.Find(entity.EmployeeID);
                _employee.EmployeeStatusID = entity.Status_New;

                serviceHistory.Context.Entry(_employee).State = System.Data.Entity.EntityState.Modified;
                serviceHistory.Context.SaveChanges();

                EmployeeStatusHistory empHistory = new EmployeeStatusHistory()
                {
                    EmployeeStatusID = entity.EmployeeStatusID,
                    EmployeeID = entity.EmployeeID,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedDate = DateTime.Now,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    StatusNote = entity.StatusNote,
                    NewStatusID = entity.NewStatusID
                };

                
                serviceHistory.Update(empHistory);
                serviceHistory.SaveChanges();

                EmployeeStatusHistory empHistoryNew = new EmployeeStatusHistory()
                {
                    CreatedBy = entity.CreatedBy,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedDate = DateTime.Now,

                    EmployeeID = entity.EmployeeID,
                    NewStatusID = entity.Status_New, // Change this status id to after rename in database
                    EndDate = entity.EndDate_New,
                    StartDate = entity.StartDate_New,
                    StatusNote = entity.StatusNote_New
                };
                serviceHistory.Create(empHistoryNew);
                serviceHistory.SaveChanges();
                                                                
                if (entity.Status_New == 5)
                {
                    SalaryService employeesalary = new SalaryService();
                    int count = employeesalary.Context.Salaries.Where(x => x.EmployeeID == entity.EmployeeID).Count();
                    if (count == 0)
                    {
                        employeesalary.Create(entity.Employee.Salaries.ToList()[0]);
                        employeesalary.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int SaveChangesReturnId(EmployeeStatusHistoryExtend entity)
        {
            return base.SaveChangesReturnId(entity);
        }
    }    
}
