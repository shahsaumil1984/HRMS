

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Service;
using Model;


namespace Api
{
    public class LeaveTypeController : GenericApiController<LeaveTypeService, LeaveType, int>, IGetList
    {
        [Authorize(Roles = "Admin")]
        public override object GetModel()
        {
            LeaveType obj = (LeaveType)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        [Authorize(Roles = "Admin")]
        public override LeaveType GetById(int id)
        {


            LeaveType obj = (from o in service.Context.LeaveTypes
                             where o.ID == id
                             select new
                             {

                                 o.ID,
                                 o.Name,
                                 o.Symbol

                             }).ToList().Select(o => new LeaveType
                             {
                                 ID = o.ID,
                                 Name = o.Name,
                                 Symbol = o.Symbol
                             }).Single<LeaveType>();
            return obj;
        }

        [Authorize(Roles = "Admin")]
        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<LeaveType> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = from o in list
                        select new
                        {

                            o.ID,
                            o.Name,
                            o.Symbol
                        };

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }
    }
}

