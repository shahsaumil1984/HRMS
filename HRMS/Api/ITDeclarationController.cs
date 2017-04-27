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
                            o.ItDeclarationYear,
                            o.PanNo,
                            o.Date
                        };  

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }

        [Authorize(Roles = "Accountant")]
        public override HttpResponseMessage Create(ItDeclarationForm entity)
        {
            entity.CreatedBy = User.Identity.Name;
            entity.ModifiedBy = User.Identity.Name;
            entity.Date = DateTime.Today;
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
                                     o.EmployeeID,
                                     o.ItDeclarationID,
                                     o.ItDeclarationYear,
                                     o.PanNo,
                                     o.AddressLine1,
                                     o.AddressLine2,
                                     o.AddressLine3,
                                     o.AddressZip,
                                     o.AddressState,
                                     o.AddressCountry,
                                     o.PurchaseOfNSC,
                                     o.InsurancePremium,
                                     o.PPF,
                                     o.HousingLoan,
                                     o.ChildrenTutionFee,
                                     o.MutualfundOrUti,
                                     o.BondsOfNabard,
                                     o.InterestOnNSC,
                                     o.FDR,
                                     o.ULIPofUTI,
                                     o.PF,
                                     o.MediclaimPremium,
                                     o.HomeLoan,
                                     o.HLAddressCountry,
                                     o.HLAddressLine1,
                                     o.HLAddressLine2,
                                     o.HLAddressLine3,
                                     o.HLAddressState,
                                     o.HLAddressZip,
                                     o.HomeRent,
                                     o.HRAddressLine11,
                                     o.HRAddressLine21,
                                     o.HRAddressLine31,
                                     o.HRAddressState1,
                                     o.HRAddressZip1,
                                     o.HRAddressCountry1,
                                     o.CreatedBy,
                                     o.CreatedDate,
                                     o.ModifiedBy,
                                     o.ModifiedDate
                                 }).ToList().Select(o => new ItDeclarationForm
                                 {
                                     EmployeeID = o.EmployeeID,
                                     ItDeclarationID= o.ItDeclarationID,
                                     ItDeclarationYear= o.ItDeclarationYear,
                                     PanNo= o.PanNo,
                                     AddressLine1 = o.AddressLine1,
                                     AddressLine2 = o.AddressLine2,
                                     AddressLine3 = o.AddressLine3,
                                     AddressZip = o.AddressZip,
                                     AddressState = o.AddressState,
                                     AddressCountry = o.AddressCountry,
                                     PurchaseOfNSC= o.PurchaseOfNSC,
                                     InsurancePremium=o.InsurancePremium,
                                     PPF=o.PPF,
                                     HousingLoan=o.HousingLoan,
                                     ChildrenTutionFee=o.ChildrenTutionFee,
                                     MutualfundOrUti=o.MutualfundOrUti,
                                     BondsOfNabard = o.BondsOfNabard,
                                     InterestOnNSC=o.InterestOnNSC,
                                     FDR=o.FDR,
                                     ULIPofUTI=o.ULIPofUTI,
                                     PF=o.PF,
                                     MediclaimPremium=o.MediclaimPremium,
                                     HomeLoan=o.HomeLoan,
                                     HLAddressCountry=o.HLAddressCountry,
                                     HLAddressLine1=o.HLAddressLine1,
                                     HLAddressLine2=o.HLAddressLine2,
                                     HLAddressLine3=o.HLAddressLine3,
                                     HLAddressState=o.HLAddressState,
                                     HLAddressZip=o.HLAddressZip,
                                     HomeRent=o.HomeRent,
                                     HRAddressLine11= o.HRAddressLine11,
                                     HRAddressLine21=o.HRAddressLine21,
                                     HRAddressLine31=o.HRAddressLine31,
                                     HRAddressState1=o.HRAddressState1,
                                     HRAddressZip1=o.HRAddressZip1,
                                     HRAddressCountry1=o.HRAddressCountry1,
                                     CreatedBy=o.CreatedBy,
                                     CreatedDate=o.CreatedDate,
                                     ModifiedBy=o.ModifiedBy,
                                     ModifiedDate=o.ModifiedDate
                                 }).Single<ItDeclarationForm>();

            // when addnew IT declaration form Assign EmployeeID to object
            //obj.EmployeeID = id;
            return obj;
        }

    }
}