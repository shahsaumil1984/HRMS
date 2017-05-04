
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Model;

namespace Service
{
  public class HolidayCalendarService : GenericService<HolidayCalendar, int>
  {
    public override void Create(HolidayCalendar entity)
    {
      //entity.ModifiedDate = DateTime.Now;
      //entity.CreatedDate = DateTime.Now;
      base.Create(entity);
    }

    public override void Update(HolidayCalendar entity)
    {
      //entity.ModifiedDate = DateTime.Now;
      base.Update(entity);
    }
  
    public override bool Validate(HolidayCalendar entity)
    {
      // throw ValidationException when an error occurs
    
      return true;
    }
  }
}
      