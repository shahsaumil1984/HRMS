using System.Runtime.Serialization;
namespace HRMS
{
    public class Helper
    {
        public enum EmployeeStatus
        {
            Active = 1,
            Probation,

            [EnumMember(Value = "Notice Period")]
            NoticePeriod,

            [EnumMember(Value = "In Active")]
            InActive
        };

        public enum SalaryStatus
        {
            Pending = 1,
            Approved

        };

        public enum Month
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }
    }

}