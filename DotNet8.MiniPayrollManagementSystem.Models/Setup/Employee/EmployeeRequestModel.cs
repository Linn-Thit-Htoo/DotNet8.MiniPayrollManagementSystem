using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee
{
    public class EmployeeRequestModel
    {
        public string? EmployeeName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? HireDate { get; set; }
        public string? Position { get; set; }
        public decimal Salary { get; set; }
    }
}
