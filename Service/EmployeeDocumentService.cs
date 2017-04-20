using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeDocumentService : GenericService<EmployeeDocument, long>
    {
        public override void Create(EmployeeDocument entity)
        {
            //entity.ModifiedDate = DateTime.Now;
            
            base.Create(entity);
        }

        public override void Update(EmployeeDocument entity)
        {
            //entity.ModifiedDate = DateTime.Now;
            base.Update(entity);
        }

        public override bool Validate(EmployeeDocument entity)
        {
            // throw ValidationException when an error occurs

            return true;
        }
    }
}
