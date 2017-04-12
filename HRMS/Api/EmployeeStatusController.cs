using Api;
using Model;
using Service;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace HRMS.Api
{
    public class EmployeeStatusController : GenericApiController<EmployeeStatusService, EmployeeStatu, int>, IGetList
    {
        // GET: DocumentType
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Admin")]
        public override object GetModel()
        {
            EmployeeStatu obj = (EmployeeStatu)base.GetModel();

            // Set Default Values Here

            return obj;
        }

        [Authorize(Roles = "Admin")]
        public override HttpResponseMessage Create(EmployeeStatu entity)
        {
            entity.CreatedBy = User.Identity.Name;
            return base.Create(entity);
        }

        [Authorize(Roles = "Admin")]
        public override HttpResponseMessage Update(EmployeeStatu entity)
        {
            entity.ModifiedBy = User.Identity.Name;
            return base.Update(entity);
        }

        [Authorize(Roles = "Admin")]
        public override EmployeeStatu GetById(int id)
        {
            EmployeeStatu obj = (from o in service.Context.EmployeeStatus
                                 where o.StatusID == id
                                 select new
                                 {
                                     o.StatusID,
                                     o.Status,
                                     o.Description,
                                     o.CreatedBy,
                                     o.CreatedDate,
                                     o.ModifiedBy,
                                     o.ModifiedDate
                                 }).ToList().Select(o => new EmployeeStatu
                                 {
                                     StatusID = o.StatusID,
                                     Status = o.Status,
                                     Description = o.Description,
                                     CreatedBy = o.CreatedBy,
                                     CreatedDate = o.CreatedDate,
                                     ModifiedBy = o.ModifiedBy,
                                     ModifiedDate = o.ModifiedDate
                                 }).Single<EmployeeStatu>();
            return obj;
        }

        [Authorize(Roles = "Admin")]
        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<EmployeeStatu> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            var query = from o in list
                        select new
                        {
                            o.StatusID,
                            o.Status,
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