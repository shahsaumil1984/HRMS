using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SalaryService : GenericService<Salary, int>
    {
        public override void Create(Salary entity)
        {
            //entity.ModifiedDate = DateTime.Today;
            //entity.CreatedDate = DateTime.Today;
            base.Create(entity);
        }

        public override void Update(Salary entity)
        {
            //entity.ModifiedDate = DateTime.Today;
            base.Update(entity);
        }

        public override bool Validate(Salary entity)
        {
            // throw ValidationException when an error occurs

            return true;
        }
    }
}
