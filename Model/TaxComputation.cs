//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaxComputation
    {
        public int TaxComputationID { get; set; }
        public Nullable<int> Basic3mAprilToJune { get; set; }
        public Nullable<int> BasicFromApril { get; set; }
        public Nullable<int> BasicFromJuly { get; set; }
        public Nullable<int> Basic9mJulyToMarch { get; set; }
        public Nullable<int> Basic12Month { get; set; }
        public Nullable<int> HRA3mAprilToJune { get; set; }
        public Nullable<int> HRAFromApril { get; set; }
        public Nullable<int> HRAFromJuly { get; set; }
        public Nullable<int> HRA9mJulyToMarch { get; set; }
        public Nullable<int> HRA12Month { get; set; }
        public Nullable<int> ConveyanceAllowance3mAprilToJune { get; set; }
        public Nullable<int> ConveyanceAllowanceFromApril { get; set; }
        public Nullable<int> ConveyanceAllowanceFromJuly { get; set; }
        public Nullable<int> ConveyanceAllowance9mJulyToMarch { get; set; }
        public Nullable<int> ConveyanceAllowance12Month { get; set; }
        public Nullable<int> OtherAllowance3mAprilToJune { get; set; }
        public Nullable<int> OtherAllowanceFromApril { get; set; }
        public Nullable<int> OtherAllowanceFromJuly { get; set; }
        public Nullable<int> OtherAllowance9mJulyToMarch { get; set; }
        public Nullable<int> OtherAllowance12Month { get; set; }
        public Nullable<int> MedicalReimbursement3mAprilToJune { get; set; }
        public Nullable<int> MedicalReimbursementFromApril { get; set; }
        public Nullable<int> MedicalReimbursementFromJuly { get; set; }
        public Nullable<int> MedicalReimbursement9mFromJulyToMarch { get; set; }
        public Nullable<int> MedicalReimbursement12Month { get; set; }
        public Nullable<int> Incentive3mAprilToJune { get; set; }
        public Nullable<int> IncentiveFromApril { get; set; }
        public Nullable<int> IncentiveFromJuly { get; set; }
        public Nullable<int> Incentive9mJulyToMarch { get; set; }
        public Nullable<int> Incentive12Month { get; set; }
        public Nullable<int> Total3mAprilToJune { get; set; }
        public Nullable<int> TotalFromApril { get; set; }
        public Nullable<int> TotalFromJuly { get; set; }
        public Nullable<int> Total9mJulyToMarch { get; set; }
        public Nullable<int> Total12Month { get; set; }
        public Nullable<int> EPF { get; set; }
        public int EmployeeID { get; set; }
        public Nullable<int> LessConveyanceAllowancesAllowed { get; set; }
        public Nullable<int> LessHRA3Months { get; set; }
        public Nullable<int> FourtyPercentOfBasicAprilToJune { get; set; }
        public Nullable<int> ActualHRAReceivedAprilToJune { get; set; }
        public Nullable<int> RentPaidAprilToJune { get; set; }
        public Nullable<int> LessHRA9Months { get; set; }
        public Nullable<int> LessDeduction80C { get; set; }
        public Nullable<int> EmployeeContributionToPF { get; set; }
        public Nullable<int> PPF { get; set; }
        public Nullable<int> MutualFundOrUTI { get; set; }
        public Nullable<int> InsurancePremium { get; set; }
        public Nullable<int> FourtyPercentOfBasicFromJuly { get; set; }
        public Nullable<int> ActualHRAReceivedFromJuly { get; set; }
        public Nullable<int> RentPaidAprilFromJuly { get; set; }
        public Nullable<int> LessDedution80DDeclared { get; set; }
        public Nullable<int> LessMedicalReimbursementAllowanceDeclared { get; set; }
        public Nullable<int> LessProfessionalTax { get; set; }
        public Nullable<int> TotalTaxableIncome { get; set; }
        public Nullable<int> TaxDue { get; set; }
        public Nullable<int> LessAdd87A { get; set; }
        public Nullable<int> TaxDueAfter87A { get; set; }
        public Nullable<int> EducationCess { get; set; }
        public Nullable<int> TotalTaxPayable { get; set; }
        public Nullable<int> TaxTillFebuary { get; set; }
        public Nullable<int> LessDedution80DAllowed { get; set; }
        public Nullable<int> LessMedicalReimbursementAllowanceAllowed { get; set; }
        public Nullable<int> BalanceTaxPayableAfterFebuary { get; set; }
        public Nullable<int> TaxForMarch { get; set; }
        public Nullable<int> Refund { get; set; }
        public Nullable<int> TaxPaid { get; set; }
        public int Year { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string TaxTillMonth { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
