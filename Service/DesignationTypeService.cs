using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DesignationTypeService : GenericService<Designation, int>
    {
        public override void Create(Designation entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.CreatedDate = DateTime.Now;
            base.Create(entity);
        }

        public override void Update(Designation entity)
        {
            entity.ModifiedDate = DateTime.Now;
            base.Update(entity);
        }

        public override bool Validate(Designation entity)
        {
            // throw ValidationException when an error occurs

            return true;
        }
    }
}
