using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee
{
    public class EmployeeModel
    {
        public long EmployeeId { get; set; }
        public string EmployeeCode { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhonNumber { get; set; } = null!;
        public string HireDate { get; set; } = null!;
        public string Position { get; set; } = null!;
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
