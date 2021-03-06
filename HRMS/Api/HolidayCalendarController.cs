

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
    public class HolidayCalendarController : GenericApiController<HolidayCalendarService, HolidayCalendar, int>, IGetList
    {
        [Authorize(Roles = "Admin")]
        public override object GetModel()
        {
            HolidayCalendar obj = (HolidayCalendar)base.GetModel();

            // Set Default Values Here

            return obj;
        }
        
        [Authorize(Roles = "Admin")]
        public override HolidayCalendar GetById(int id)
        {


            HolidayCalendar obj = (from o in service.Context.HolidayCalendars
                                   where o.ID == id
                                   select new
                                   {

                                       o.ID,
                                       o.HolidayDate,
                                       o.Description,
                                       o.CreatedBy,
                                       o.CreatedDate,
                                       o.ModifiedBy,
                                       o.ModifiedDate

                                   }).ToList().Select(o => new HolidayCalendar
                                   {
                                       ID = o.ID,
                                       HolidayDate = o.HolidayDate,
                                       Description = o.Description,
                                       CreatedBy = o.CreatedBy,
                                       CreatedDate = o.CreatedDate,
                                       ModifiedBy = o.ModifiedBy,
                                       ModifiedDate = o.ModifiedDate
                                   }).Single<HolidayCalendar>();
            return obj;
        }

        [Authorize(Roles = "Admin")]
        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<HolidayCalendar> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = from o in list
                        select new
                        {

                            o.ID,
                            o.HolidayDate,
                            o.Description,
                            o.CreatedBy,
                            o.CreatedDate,
                            o.ModifiedBy,
                            o.ModifiedDate
                        };

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }
    }
}

