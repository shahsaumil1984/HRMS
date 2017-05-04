using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DocumentService : GenericService<Document, long>
    {
        public override void Create(Document entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.CreatedDate = DateTime.Now;
            base.Create(entity);
        }

        public override void Update(Document entity)
        {
            entity.ModifiedDate = DateTime.Now;
            base.Update(entity);
        }

        public override bool Validate(Document entity)
        {
            // throw ValidationException when an error occurs

            return true;
        }
    }
}
