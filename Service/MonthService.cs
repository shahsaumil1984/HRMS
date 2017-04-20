using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MonthService : GenericService<Month, int>
    {
        public override void Create(Month entity)
        {
            //entity.ModifiedDate = DateTime.Now;
            //entity.CreatedDate = DateTime.Now;
            base.Create(entity);
        }

        public override void Update(Month entity)
        {
            //entity.ModifiedDate = DateTime.Now;
            base.Update(entity);
        }

        public override bool Validate(Month entity)
        {
            // throw ValidationException when an error occurs

            return true;
        }
    }
}
