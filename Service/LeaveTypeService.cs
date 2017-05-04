
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Model;

namespace Service
{
  public class LeaveTypeService : GenericService<LeaveType, int>
  {
    public override void Create(LeaveType entity)
    {
      //entity.ModifiedDate = DateTime.Now;
      //entity.CreatedDate = DateTime.Now;
      base.Create(entity);
    }

    public override void Update(LeaveType entity)
    {
      //entity.ModifiedDate = DateTime.Now;
      base.Update(entity);
    }
  
    public override bool Validate(LeaveType entity)
    {
      // throw ValidationException when an error occurs
    
      return true;
    }
  }
}
      