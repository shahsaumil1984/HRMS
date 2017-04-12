using Api;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS;
namespace HRMS.Api
{
    public class EmployeeDocumentController : GenericApiController<EmployeeDocumentService, EmployeeDocument, long>, IGetList
    {
        //// GET: EmployeeDocument
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Admin")]
        public override object GetModel()
        {

            
          

            EmployeeDocument obj = (EmployeeDocument)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        [Authorize(Roles = "Admin")]
        public override EmployeeDocument GetById(long id)
        {
            EmployeeDocument obj = (from o in service.Context.EmployeeDocuments
                                    where o.EmployeeDocumentID == id
                                    select new
                                    {
                                        o.EmployeeDocumentID,
                                        o.EmployeeID,

                                    }).ToList().Select(o => new EmployeeDocument
                                    {
                                        EmployeeDocumentID=o.EmployeeDocumentID,
                                        EmployeeID = o.EmployeeID
                                    }).Single<EmployeeDocument>();
            return obj;
        }

        [Authorize(Roles = "Admin")]
        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<EmployeeDocument> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            service.Context.Configuration.ProxyCreationEnabled = false;
            var query = from o in list
                        select new
                        {
                            o.EmployeeDocumentID,
                            o.DocumentID,
                            o.EmployeeID,
                            o.DocumentName,
                            o.DocumentType//,
                            //o.DocumentTypeID
                        };

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }
    }
}