

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
        public class HolidayCalendarController : GenericApiController<HolidayCalendarService, HolidayCalendar, int>,IGetList
        {          
          public override object GetModel()
          {
            HolidayCalendar obj = (HolidayCalendar)base.GetModel();
            
            // Set Default Values Here
                        
            return obj;
          }  
          
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
                              o.Created,
                              o.ModifiedBy,
                              o.Modified
      
                           }).ToList().Select(o => new HolidayCalendar
                                { 
                                  ID = o.ID,HolidayDate = o.HolidayDate,Description = o.Description,CreatedBy = o.CreatedBy,Created = o.Created,ModifiedBy = o.ModifiedBy,Modified = o.Modified
                                  }).Single<HolidayCalendar>();
             return obj;              
          }
          
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
                              o.Created,
                              o.ModifiedBy,
                              o.Modified
                          };
						  
			 PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

              return pQuery;
          }
      }
}

  