using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TaxComputationService : GenericService<TaxComputation, int>
    {
        public override void Create(TaxComputation entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            base.Create(entity);
        }

        public override void Update(TaxComputation entity)
        {
            entity.ModifiedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
