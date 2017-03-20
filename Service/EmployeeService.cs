
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Model;

namespace Service
{
  public class EmployeeService : GenericService<Employee, int>
  {
    public override void Create(Employee entity)
    {
      //entity.ModifiedDate = DateTime.Today;
      //entity.CreatedDate = DateTime.Today;
      base.Create(entity);
    }

    public override void Update(Employee entity)
    {
      //entity.ModifiedDate = DateTime.Today;
      base.Update(entity);
    }
  
    public override bool Validate(Employee entity)
    {
      // throw ValidationException when an error occurs
    
      return true;
    }
  }
}
      