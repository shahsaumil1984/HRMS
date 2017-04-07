using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeStatusService : GenericService<EmployeeStatus, int>
    {
        public override void Create(EmployeeStatus entity)
        {
            entity.CreatedDate = DateTime.Now;
            base.Create(entity);
        }

        public override void Update(EmployeeStatus entity)
        {
            entity.ModifiedDate = DateTime.Now;
            base.Update(entity);
        }

        public override bool Validate(EmployeeStatus entity)
        {
            // throw ValidationException when an error occurs

            return true;
        }
    }
}
