using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DocumentTypeService : GenericService<DocumentType, int>
    {
        public override void Create(DocumentType entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.CreatedDate = DateTime.Now;
            base.Create(entity);
        }

        public override void Update(DocumentType entity)
        {
            entity.ModifiedDate = DateTime.Now;
            base.Update(entity);
        }

        public override bool Validate(DocumentType entity)
        {
            // throw ValidationException when an error occurs

            return true;
        }
    }
}
