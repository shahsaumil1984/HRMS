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
    public class TaxComputationController : GenericApiController<TaxComputationService, TaxComputation, int>, IGetList
    {
        [Authorize(Roles = "Accountant")]
        public PaginationQueryable GetList(int? pageIndex = null, int? pageSize = null, string filter = null, string orderBy = null, string includeProperties = "")
        {
            IQueryable<TaxComputation> list = service.Get(pageIndex, pageSize, filter, orderBy, includeProperties);
            service.Context.Configuration.ProxyCreationEnabled = false;
            var query = from o in list
                        select new
                        {
                            o.TaxComputationID,
                            o.ActualHRAReceivedAprilToJune,
                            o.ActualHRAReceivedFromJuly,
                            o.BalanceTaxPayableAfterFebuary,
                            o.Basic12Month,
                            o.Basic3mAprilToJune,
                            o.Basic9mJulyToMarch,
                            o.BasicFromApril,
                            o.BasicFromJuly,
                            o.ConveyanceAllowance12Month,
                            o.ConveyanceAllowance3mAprilToJune,
                            o.ConveyanceAllowance9mJulyToMarch,
                            o.ConveyanceAllowanceFromApril,
                            o.ConveyanceAllowanceFromJuly,
                            o.EducationCess,
                            o.Employee,
                            o.EmployeeContributionToPF,
                            o.EPF,
                            o.FourtyPercentOfBasicAprilToJune,
                            o.FourtyPercentOfBasicFromJuly,
                            o.HRA12Month,
                            o.HRA3mAprilToJune,
                            o.HRA9mJulyToMarch,
                            o.HRAFromApril,
                            o.HRAFromJuly,
                            o.Incentive12Month,
                            o.Incentive3mAprilToJune,
                            o.Incentive9mJulyToMarch,
                            o.IncentiveFromApril,
                            o.IncentiveFromJuly,
                            o.InsurancePremium,
                            o.LessAdd87A,
                            o.LessConveyanceAllowancesAllowed,
                            o.LessDeduction80C,
                            o.LessDedution80DAllowed,
                            o.LessDedution80DDeclared,
                            o.LessHRA3Months,
                            o.LessHRA9Months,
                            o.LessMedicalReimbursementAllowanceAllowed,
                            o.LessMedicalReimbursementAllowanceDeclared,
                            o.LessProfessionalTax,
                            o.MedicalReimbursement12Month,
                            o.MedicalReimbursement3mAprilToJune,
                            o.MedicalReimbursement9mFromJulyToMarch,
                            o.MedicalReimbursementFromApril,
                            o.MedicalReimbursementFromJuly,
                            o.MutualFundOrUTI,
                            o.OtherAllowance12Month,
                            o.OtherAllowance3mAprilToJune,
                            o.OtherAllowance9mJulyToMarch,
                            o.OtherAllowanceFromApril,
                            o.OtherAllowanceFromJuly,
                            o.PPF,
                            o.Refund,
                            o.RentPaidAprilFromJuly,
                            o.RentPaidAprilToJune,
                            o.TaxDue,
                            o.TaxDueAfter87A,
                            o.TaxForMarch,
                            o.TaxPaid,
                            o.TaxTillFebuary,
                            o.Total12Month,
                            o.Total3mAprilToJune,
                            o.Total9mJulyToMarch,
                            o.TotalFromApril,
                            o.TotalFromJuly,
                            o.TotalTaxableIncome,
                            o.TotalTaxPayable,
                            o.Year,
                            o.CreatedBy,
                            o.CreatedDate,
                            o.ModifiedBy,
                            o.ModifiedDate
                        };

            PaginationQueryable pQuery = new PaginationQueryable(query, pageIndex, pageSize, service.TotalRowCount);

            return pQuery;
        }

        [Authorize(Roles = "Accountant")]
        public override HttpResponseMessage Create(TaxComputation entity)
        {
            entity.CreatedBy = User.Identity.Name;
            entity.ModifiedBy = User.Identity.Name;
            return base.Create(entity);
        }

        [Authorize(Roles = "Accountant")]
        public override HttpResponseMessage Update(TaxComputation entity)
        {
            entity.ModifiedBy = User.Identity.Name;
            return base.Update(entity);
        }

        [Authorize(Roles = "Accountant")]
        public override TaxComputation GetById(int id)
        {
            service.Context.Configuration.ProxyCreationEnabled = false;
            TaxComputation obj = (from o in service.Context.TaxComputations
                                  where o.TaxComputationID == id
                                  select new
                                  {
                                      o.TaxComputationID,
                                      o.ActualHRAReceivedAprilToJune,
                                      o.ActualHRAReceivedFromJuly,
                                      o.BalanceTaxPayableAfterFebuary,
                                      o.Basic12Month,
                                      o.Basic3mAprilToJune,
                                      o.Basic9mJulyToMarch,
                                      o.BasicFromApril,
                                      o.BasicFromJuly,
                                      o.ConveyanceAllowance12Month,
                                      o.ConveyanceAllowance3mAprilToJune,
                                      o.ConveyanceAllowance9mJulyToMarch,
                                      o.ConveyanceAllowanceFromApril,
                                      o.ConveyanceAllowanceFromJuly,
                                      o.EducationCess,
                                      o.Employee,
                                      o.EmployeeID,
                                      o.EmployeeContributionToPF,
                                      o.EPF,
                                      o.FourtyPercentOfBasicAprilToJune,
                                      o.FourtyPercentOfBasicFromJuly,
                                      o.HRA12Month,
                                      o.HRA3mAprilToJune,
                                      o.HRA9mJulyToMarch,
                                      o.HRAFromApril,
                                      o.HRAFromJuly,
                                      o.Incentive12Month,
                                      o.Incentive3mAprilToJune,
                                      o.Incentive9mJulyToMarch,
                                      o.IncentiveFromApril,
                                      o.IncentiveFromJuly,
                                      o.InsurancePremium,
                                      o.LessAdd87A,
                                      o.LessConveyanceAllowancesAllowed,
                                      o.LessDeduction80C,
                                      o.LessDedution80DAllowed,
                                      o.LessDedution80DDeclared,
                                      o.LessHRA3Months,
                                      o.LessHRA9Months,
                                      o.LessMedicalReimbursementAllowanceAllowed,
                                      o.LessMedicalReimbursementAllowanceDeclared,
                                      o.LessProfessionalTax,
                                      o.MedicalReimbursement12Month,
                                      o.MedicalReimbursement3mAprilToJune,
                                      o.MedicalReimbursement9mFromJulyToMarch,
                                      o.MedicalReimbursementFromApril,
                                      o.MedicalReimbursementFromJuly,
                                      o.MutualFundOrUTI,
                                      o.OtherAllowance12Month,
                                      o.OtherAllowance3mAprilToJune,
                                      o.OtherAllowance9mJulyToMarch,
                                      o.OtherAllowanceFromApril,
                                      o.OtherAllowanceFromJuly,
                                      o.PPF,
                                      o.Refund,
                                      o.RentPaidAprilFromJuly,
                                      o.RentPaidAprilToJune,
                                      o.TaxDue,
                                      o.TaxDueAfter87A,
                                      o.TaxForMarch,
                                      o.TaxPaid,
                                      o.TaxTillFebuary,
                                      o.Total12Month,
                                      o.Total3mAprilToJune,
                                      o.Total9mJulyToMarch,
                                      o.TotalFromApril,
                                      o.TotalFromJuly,
                                      o.TotalTaxableIncome,
                                      o.TotalTaxPayable,
                                      o.Year,
                                      o.CreatedBy,
                                      o.CreatedDate,
                                      o.ModifiedBy,
                                      o.ModifiedDate
                                  }).ToList().Select(o => new TaxComputation
                                  {
                                      TaxComputationID = o.TaxComputationID,
                                      ActualHRAReceivedAprilToJune = o.ActualHRAReceivedAprilToJune,
                                      ActualHRAReceivedFromJuly = o.ActualHRAReceivedFromJuly,
                                      BalanceTaxPayableAfterFebuary = o.BalanceTaxPayableAfterFebuary,
                                      Basic12Month = o.Basic12Month,
                                      Basic3mAprilToJune = o.Basic3mAprilToJune,
                                      Basic9mJulyToMarch = o.Basic9mJulyToMarch,
                                      BasicFromApril = o.BasicFromApril,
                                      BasicFromJuly = o.BasicFromJuly,
                                      ConveyanceAllowance12Month = o.ConveyanceAllowance12Month,
                                      ConveyanceAllowance3mAprilToJune = o.ConveyanceAllowance3mAprilToJune,
                                      ConveyanceAllowance9mJulyToMarch = o.ConveyanceAllowance9mJulyToMarch,
                                      ConveyanceAllowanceFromApril = o.ConveyanceAllowanceFromApril,
                                      ConveyanceAllowanceFromJuly = o.ConveyanceAllowanceFromJuly,
                                      EducationCess = o.EducationCess,
                                      Employee = o.Employee,
                                      EmployeeID = o.EmployeeID,
                                      EmployeeContributionToPF = o.EmployeeContributionToPF,
                                      EPF = o.EPF,
                                      FourtyPercentOfBasicAprilToJune = o.FourtyPercentOfBasicAprilToJune,
                                      FourtyPercentOfBasicFromJuly = o.FourtyPercentOfBasicFromJuly,
                                      HRA12Month = o.HRA12Month,
                                      HRA3mAprilToJune = o.HRA3mAprilToJune,
                                      HRA9mJulyToMarch = o.HRA9mJulyToMarch,
                                      HRAFromApril = o.HRAFromApril,
                                      HRAFromJuly = o.HRAFromJuly,
                                      Incentive12Month = o.Incentive12Month,
                                      Incentive3mAprilToJune = o.Incentive3mAprilToJune,
                                      Incentive9mJulyToMarch = o.Incentive9mJulyToMarch,
                                      IncentiveFromApril = o.IncentiveFromApril,
                                      IncentiveFromJuly = o.IncentiveFromJuly,
                                      InsurancePremium = o.InsurancePremium,
                                      LessAdd87A = o.LessAdd87A,
                                      LessConveyanceAllowancesAllowed = o.LessConveyanceAllowancesAllowed,
                                      LessDeduction80C = o.LessDeduction80C,
                                      LessDedution80DAllowed = o.LessDedution80DAllowed,
                                      LessDedution80DDeclared = o.LessDedution80DDeclared,
                                      LessHRA3Months = o.LessHRA3Months,
                                      LessHRA9Months = o.LessHRA9Months,
                                      LessMedicalReimbursementAllowanceAllowed = o.LessMedicalReimbursementAllowanceAllowed,
                                      LessMedicalReimbursementAllowanceDeclared = o.LessMedicalReimbursementAllowanceDeclared,
                                      LessProfessionalTax = o.LessProfessionalTax,
                                      MedicalReimbursement12Month = o.MedicalReimbursement12Month,
                                      MedicalReimbursement3mAprilToJune = o.MedicalReimbursement3mAprilToJune,
                                      MedicalReimbursement9mFromJulyToMarch = o.MedicalReimbursement9mFromJulyToMarch,
                                      MedicalReimbursementFromApril = o.MedicalReimbursementFromApril,
                                      MedicalReimbursementFromJuly = o.MedicalReimbursementFromJuly,
                                      MutualFundOrUTI = o.MutualFundOrUTI,
                                      OtherAllowance12Month = o.OtherAllowance12Month,
                                      OtherAllowance3mAprilToJune = o.OtherAllowance3mAprilToJune,
                                      OtherAllowance9mJulyToMarch = o.OtherAllowance9mJulyToMarch,
                                      OtherAllowanceFromApril = o.OtherAllowanceFromApril,
                                      OtherAllowanceFromJuly = o.OtherAllowanceFromJuly,
                                      PPF = o.PPF,
                                      Refund = o.Refund,
                                      RentPaidAprilFromJuly = o.RentPaidAprilFromJuly,
                                      RentPaidAprilToJune = o.RentPaidAprilToJune,
                                      TaxDue = o.TaxDue,
                                      TaxDueAfter87A = o.TaxDueAfter87A,
                                      TaxForMarch = o.TaxForMarch,
                                      TaxPaid = o.TaxPaid,
                                      TaxTillFebuary = o.TaxTillFebuary,
                                      Total12Month = o.Total12Month,
                                      Total3mAprilToJune = o.Total3mAprilToJune,
                                      Total9mJulyToMarch = o.Total9mJulyToMarch,
                                      TotalFromApril = o.TotalFromApril,
                                      TotalFromJuly = o.TotalFromJuly,
                                      TotalTaxableIncome = o.TotalTaxableIncome,
                                      TotalTaxPayable = o.TotalTaxPayable,
                                      Year = o.Year,
                                      CreatedBy = o.CreatedBy,
                                      CreatedDate = o.CreatedDate,
                                      ModifiedBy = o.ModifiedBy,
                                      ModifiedDate = o.ModifiedDate
                                  }).Single<TaxComputation>();
            return obj;
        }

    }
}