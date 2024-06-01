namespace DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll
{
    public class PayrollRequestModel
    {
        public string? EmployeeName { get; set; }
        public string? PayDate { get; set; }
        public decimal GrossPay { get; set; }
        public decimal NetPay { get; set; }
        public decimal? DeductionAmount { get; set; }
        public decimal? BonusAmount { get; set; }
        public decimal? TaxAmount { get; set; }
    }
}
