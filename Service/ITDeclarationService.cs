using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ITDeclarationService : GenericService<ItDeclarationForm, int>
    {
        public override void Create(ItDeclarationForm entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            base.Create(entity);
        }

        public override void Update(ItDeclarationForm entity)
        {
            entity.ModifiedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
