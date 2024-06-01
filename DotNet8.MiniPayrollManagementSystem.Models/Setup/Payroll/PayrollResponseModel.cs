using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll
{
    public class PayrollResponseModel
    {
        public string PId { get; set; } = null!;
        public string EmployeeName { get; set; } = null!;
        public string PayDate { get; set; } = null!;
        public decimal GrossPay { get; set; }
        public decimal NetPay { get; set; }
        public decimal DeductionAmount { get; set; }
        public decimal BonusAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public string EmployeeCode { get; set; } = null!;
    }
}
