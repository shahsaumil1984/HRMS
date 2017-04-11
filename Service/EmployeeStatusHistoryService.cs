using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeStatusHistoryService : GenericService<EmployeeStatusHistory, int>
    {
        public override void Create(EmployeeStatusHistory entity)
        {
            entity.CreatedDate = DateTime.Now;
            base.Create(entity);
        }

        public override void Update(EmployeeStatusHistory entity)
        {
            entity.ModifiedDate = DateTime.Now;
            base.Update(entity);
        }

        public override bool Validate(EmployeeStatusHistory entity)
        {
            // throw ValidationException when an error occurs

            return true;
        }
    }
}
