using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Service;

using ViewModel;

namespace Api
{
    public interface IGetList
    {
        PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "");
    }

    public abstract class GenericApiController<TService, TEntity, TKey> : ApiController
        where TService : GenericService<TEntity, TKey>, new()
        where TEntity : class, new()
    {


        
       
        protected TService service = new TService();

        public virtual object GetModel()
        {
            return new TEntity();
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return service.Get();
        }

        //[Authorize]
        protected virtual IQueryable GetListQueryable(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            return list;
        }

        public virtual TEntity GetById(TKey id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public virtual HttpResponseMessage Create(TEntity entity)
        {
            try
            {
                service.Create(entity);
                TKey id = service.SaveChangesReturnId(entity);
                return HttpSuccess(id);
            }
            catch (Exception expt)
            {
                return HttpError(expt);
            }
        }

        public HttpResponseMessage HttpUnAuthorized()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            //response.Content = new StringContent("Not allowed"); // Put the message in the response body (text/plain content).
            //response.RequestMessage = Request;
            return response;
        }

        [HttpPut]
        public virtual HttpResponseMessage Update(TEntity entity)
        {
            try
            {
                service.Update(entity);
                TKey id = service.SaveChangesReturnId(entity);
                return HttpSuccess(id);
            }
            catch (Exception expt)
            {
                return HttpError(expt);
            }
        }

        [HttpDelete]
        public virtual HttpResponseMessage Delete(TEntity entity)
        {
            try
            {
                service.Delete(entity);
                service.SaveChanges();
                return HttpSuccess();
            }
            catch (Exception expt)
            {
                return HttpError(expt);
            }
        }

        [HttpDelete]
        public virtual HttpResponseMessage Delete(int id)
        {
            try
            {
                service.Delete(id);
                service.SaveChanges();
                return HttpSuccess();
            }
            catch (Exception expt)
            {
                return HttpError(expt);
            }
        }

        public HttpResponseMessage HttpError(Exception expt)
        {
            LogError(expt);

            string errMsg = expt.Message;
            if (expt.InnerException != null)
            {
                errMsg += " [Inner]" + expt.InnerException.Message;
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Error = errMsg });
        }


        public HttpResponseMessage HttpError()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage HttpSuccess()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage HttpSuccess(TKey id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        /*public int UserID
        {
            get
            {
                return AuthenticationService.CurrentUserID(User);
            }
        }*/

        public virtual void LogError(Exception expt)
        {

        }

        public virtual void Log(string logEntry)
        {

        }
    }

    public class PaginationQueryable
    {
        public IQueryable List;
        public int TotalRows = 0;
        public int? PageIndex = 0;
        public int? PageSize = 0;

        public PaginationQueryable(IQueryable query, int? pageIndex, int? pageSize, int totalRowCount)
        {
            this.List = query;
            this.TotalRows = totalRowCount;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
    }
}