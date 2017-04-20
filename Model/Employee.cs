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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.EmployeeDocuments = new HashSet<EmployeeDocument>();
            this.EmployeeStatusHistories = new HashSet<EmployeeStatusHistory>();
            this.LeaveMasters = new HashSet<LeaveMaster>();
            this.LeaveTakens = new HashSet<LeaveTaken>();
            this.Salaries = new HashSet<Salary>();
        }
    
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PermanentAddressLine1 { get; set; }
        public string PermanentAddressLine2 { get; set; }
        public string PermanentAddressLine3 { get; set; }
        public string PermanentAddressState { get; set; }
        public string PermanentAddressCountry { get; set; }
        public string PermanentAddressZip { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressState { get; set; }
        public string AddressCountry { get; set; }
        public string AddressZip { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public System.DateTime DateOfjoining { get; set; }
        public System.DateTime ProbationPeriodEndDate { get; set; }
        public Nullable<bool> HasResigned { get; set; }
        public Nullable<System.DateTime> DateOfResignation { get; set; }
        public Nullable<System.DateTime> LastWorkingDay { get; set; }
        public string PAN { get; set; }
        public string IDCardNumber { get; set; }
        public string IDCardType { get; set; }
        public string SalaryAccountNumber { get; set; }
        public string SalaryAccountBank { get; set; }
        public string SalaryAccountBankAddress { get; set; }
        public string SalaryAccountIFSCCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string PermanentAddressCity { get; set; }
        public string AddressCity { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public byte[] EmployeePhoto { get; set; }
        public string EmployeeCode { get; set; }
        public Nullable<int> EmployeeStatusID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string AlternatePhone { get; set; }
    
        public virtual Designation Designation { get; set; }
        public virtual EmployeeStatu EmployeeStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeDocument> EmployeeDocuments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeStatusHistory> EmployeeStatusHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveMaster> LeaveMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveTaken> LeaveTakens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
