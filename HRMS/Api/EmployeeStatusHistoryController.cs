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
    public class EmployeeStatusHistoryController  : GenericApiController<EmployeeStatusHistoryService, EmployeeStatusHistory, int>, IGetList
    {
        
        HRMSEntities dbContext = new HRMSEntities();
        public override object GetModel()
        {
            EmployeeStatusHistory obj = (EmployeeStatusHistory)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        public override HttpResponseMessage Create(EmployeeStatusHistory entity)
        {

            try
            {
                // IStart To update Employee table for employee's latest status
                var _employee = dbContext.Employees.Find(entity.EmployeeID);
                _employee.EmployeeID = entity.EmployeeID;
                _employee.EmployeeStatusID = entity.NewStatusID;

                dbContext.Entry(_employee).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                // IEnd To update Employee table for employee's latest status
                
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return base.Create(entity);
        }
        public override HttpResponseMessage Update(EmployeeStatusHistory entity)
        {
          
            entity.ModifiedBy = User.Identity.Name;
            service.Update(entity);

            return HttpSuccess();
            
        }
 
        [HttpGet]
        public override EmployeeStatusHistory GetById(int id)
        {
            service.Context.Configuration.ProxyCreationEnabled = false;
            
            EmployeeStatusHistory obj = (from o in service.Context.EmployeeStatusHistories
                                         where o.EmployeeID == id
                                  select new 
                                  {
                                      o.EmployeeID,
                                      o.EmployeeStatusID,
                                      o.EmployeeStatu,
                                      o.StartDate,
                                      o.EndDate,
                                      o.StatusNote,
                                      o.NewStatusID
                                  }).ToList().Select(o => new EmployeeStatusHistoryExtend
                                  {
                                      EmployeeID = o.EmployeeID,
                                      EmployeeStatusID = o.EmployeeStatusID,
                                      EmployeeStatu = o.EmployeeStatu,
                                      StartDate = o.StartDate,
                                      EndDate = o.EndDate,
                                      StatusNote = o.StatusNote,
                                      NewStatusID = o.NewStatusID

                                  }).OrderByDescending(o=>o.EmployeeStatusID).Take(1).Single<EmployeeStatusHistory>();
            return (EmployeeStatusHistoryExtend)obj;
        }

        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            
            IQueryable<EmployeeStatusHistory> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            service.Context.Configuration.ProxyCreationEnabled = false;
            var query = (from o in list
                        select new
                        {
                            EmployeeStatusID = o.EmployeeStatusID,
                            Employee = o.Employee,
                            EmployeeStatus = o.EmployeeStatu,
                            StartDate = o.StartDate ,
                            EndDate = o.EndDate,
                            CreatedDate = o.CreatedDate,
                            CreatedBy = o.CreatedBy,
                            ModifiedBy= o.ModifiedBy,
                            ModifiedDate= o.ModifiedDate,
                            StatusNote = o.StatusNote
                        }).Select(o =>
                            new
                            {
                                EmployeeStatusID = o.EmployeeStatusID,
                                Employee = o.Employee.FullName,
                                EmployeeID = o.Employee.EmployeeID,
                                EmployeeStatus = o.EmployeeStatus,
                                StartDate = o.StartDate,
                                EndDate = o.EndDate,
                                CreatedDate = o.CreatedDate,
                                CreatedBy = o.CreatedBy,
                                ModifiedBy = o.ModifiedBy,
                                ModifiedDate = o.ModifiedDate,
                                StatusNote = o.StatusNote
                            }
                        );

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);
            return pQuery;
        }
    }
}