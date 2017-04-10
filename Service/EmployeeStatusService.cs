using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeStatusService : GenericService<EmployeeStatu, int>
    {
        public override void Create(EmployeeStatu entity)
        {
            entity.CreatedDate = DateTime.Now;
            base.Create(entity);
        }

        public override void Update(EmployeeStatu entity)
        {
            entity.ModifiedDate = DateTime.Now;
            base.Update(entity);
        }

        public override bool Validate(EmployeeStatu entity)
        {
            // throw ValidationException when an error occurs

            return true;
        }
    }
}
