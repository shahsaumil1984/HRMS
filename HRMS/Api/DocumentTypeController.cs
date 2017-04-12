using Api;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Api
{
    public class DocumentTypeController : GenericApiController<DocumentTypeService, DocumentType, int>, IGetList
    {
        // GET: DocumentType
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Admin")]
        public override object GetModel()
        {
            DocumentType obj = (DocumentType)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        [Authorize(Roles = "Admin")]
        public override DocumentType GetById(int id)
        {
            DocumentType obj = (from o in service.Context.DocumentTypes
                            where o.DocumentTypeID == id
                            select new
                            {
                                o.DocumentTypeID,
                                o.Description,
                                o.CreatedBy,
                                o.CreatedDate,
                                o.ModifiedBy,
                                o.ModifiedDate

                            }).ToList().Select(o => new DocumentType
                            {
                                DocumentTypeID = o.DocumentTypeID,
                                Description = o.Description,
                                CreatedBy = o.CreatedBy,
                                CreatedDate = o.CreatedDate,
                                ModifiedBy = o.ModifiedBy,
                                ModifiedDate = o.ModifiedDate
                            }).Single<DocumentType>();
            return obj;
        }

        [Authorize(Roles = "Admin")]
        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<DocumentType> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = from o in list
                        select new
                        {
                            o.DocumentTypeID,
                            o.Description,
                            o.CreatedBy,
                            o.CreatedDate,
                            o.ModifiedBy,
                            o.ModifiedDate
                        };

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }
    }
}