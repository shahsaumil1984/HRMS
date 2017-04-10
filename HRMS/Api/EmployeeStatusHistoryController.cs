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
        // GET: DocumentType
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public override object GetModel()
        {
            EmployeeStatusHistory obj = (EmployeeStatusHistory)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        public override HttpResponseMessage Create(EmployeeStatusHistory entity)
        {
            entity.CreatedBy = User.Identity.Name;
            return base.Create(entity);
        }
        public override HttpResponseMessage Update(EmployeeStatusHistory entity)
        {
            entity.ModifiedBy= User.Identity.Name;
            return base.Update(entity); 
        }

        public override EmployeeStatusHistory GetById(int id)
        {


            EmployeeStatusHistory obj = (from o in service.Context.EmployeeStatusHistories
                                         where o.EmployeeID == id
                                  select new
                                  {
                                      o.EmployeeStatusID,
                                      o.EmployeeStatu,
                                      o.EmployeeStatu1,
                                      o.Employee,
                                      o.StartDate,
                                      o.EndDate,
                                      o.StatusNote,
                                      o.CreatedBy,
                                      o.CreatedDate,
                                      o.ModifiedBy,
                                      o.ModifiedDate

                                  }).ToList().Select(o => new EmployeeStatusHistory
                                  {
                                      EmployeeStatusID = o.EmployeeStatusID,
                                      EmployeeStatu = o.EmployeeStatu,
                                      EmployeeStatu1 = o.EmployeeStatu1,
                                      StartDate = o.StartDate,
                                      EndDate = o.EndDate,
                                      StatusNote = o.StatusNote,
                                      CreatedBy = o.CreatedBy,
                                      CreatedDate = o.CreatedDate,
                                      ModifiedBy = o.ModifiedBy,
                                      ModifiedDate = o.ModifiedDate
                                  }).Single<EmployeeStatusHistory>();
            return obj;
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
                            EmployeeStatu = o.EmployeeStatu,
                            EmployeeStatu1 = o.EmployeeStatu1,
                            StartDate = o.StartDate,
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
                                EmployeeStatu = o.EmployeeStatu,
                                EmployeeStatu1 = o.EmployeeStatu1,
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