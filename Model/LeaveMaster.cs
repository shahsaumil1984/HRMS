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
    
    public partial class LeaveMaster
    {
        public int ID { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> LeaveTypeId { get; set; }
        public Nullable<decimal> LeavesAdded { get; set; }
        public Nullable<System.DateTime> LeaveValueDate { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual LeaveType LeaveType { get; set; }
    }
}
