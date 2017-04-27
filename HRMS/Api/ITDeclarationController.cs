using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Api
{
    public class ITDeclarationController : GenericApiController<ITDeclarationService, ItDeclarationForm, int>, IGetList
    {
        [Authorize(Roles = "Accountant")]
        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<ItDeclarationForm> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = from o in list
                        select new
                        {
                            o.ItDeclarationID,
                            o.ItDeclarationYear
                        };  

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }

        [Authorize(Roles = "Accountant")]
        public override HttpResponseMessage Create(ItDeclarationForm entity)
        {
            entity.CreatedBy = User.Identity.Name;
            entity.ModifiedBy = User.Identity.Name;
            return base.Create(entity);
        }

        [Authorize(Roles = "Accountant")]
        public override HttpResponseMessage Update(ItDeclarationForm entity)
        {
            entity.ModifiedBy = User.Identity.Name;
            return base.Update(entity);
        }

        [Authorize(Roles = "Accountant")]
        public override ItDeclarationForm GetById(int id)
        {
            ItDeclarationForm obj = (from o in service.Context.ItDeclarationForms
                                  where o.ItDeclarationID == id
                                 select new
                                 {
                                     o.ItDeclarationID,
                                     o.ItDeclarationYear,
                                     o.CreatedBy,
                                     o.CreatedDate,
                                     o.ModifiedBy,
                                     o.ModifiedDate
                                 }).ToList().Select(o => new ItDeclarationForm
                                 {
                                     ItDeclarationID = o.ItDeclarationID,
                                     ItDeclarationYear = o.ItDeclarationYear,
                                     CreatedBy = o.CreatedBy,
                                     CreatedDate = o.CreatedDate,
                                     ModifiedBy = o.ModifiedBy,
                                     ModifiedDate = o.ModifiedDate
                                 }).Single<ItDeclarationForm>();
            return obj;
        }

    }
}