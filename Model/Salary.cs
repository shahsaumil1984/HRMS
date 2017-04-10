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
    
    public partial class Salary
    {
        public int SalaryID { get; set; }
        public int EmployeeID { get; set; }
        public int MonthID { get; set; }
        public decimal Basic { get; set; }
        public decimal HRA { get; set; }
        public decimal ConveyanceAllowance { get; set; }
        public decimal OtherAllowance { get; set; }
        public decimal MedicalReimbursement { get; set; }
        public decimal AdvanceSalary { get; set; }
        public decimal Incentive { get; set; }
        public decimal PLI { get; set; }
        public decimal Exgratia { get; set; }
        public decimal ReimbursementOfexp { get; set; }
        public decimal TDS { get; set; }
        public decimal EPF { get; set; }
        public decimal ProfessionalTax { get; set; }
        public decimal Leave { get; set; }
        public decimal Advance { get; set; }
        public decimal YTDS { get; set; }
        public string Note { get; set; }
        public decimal Salary1 { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> TotalPayment { get; set; }
        public int Days { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string SalaryStatus { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Month Month { get; set; }
    }
}
