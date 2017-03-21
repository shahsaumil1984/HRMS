
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Model;

namespace Service
{
  public class DocumentUploadService : GenericService<Document, int>
  {
    public override void Create(Document entity)
    {
      //entity.ModifiedDate = DateTime.Today;
      //entity.CreatedDate = DateTime.Today;
      base.Create(entity);
    }

    public override void Update(Document entity)
    {
      //entity.ModifiedDate = DateTime.Today;
      base.Update(entity);
    }
  
    public override bool Validate(Document entity)
    {
      // throw ValidationException when an error occurs
    
      return true;
    }
  }
}
      