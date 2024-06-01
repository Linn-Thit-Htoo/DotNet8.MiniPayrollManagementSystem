namespace DotNet8.MiniPayrollManagementSystem.DbService.Entities;

public partial class TblPayroll
{
    public string PId { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public string PayDate { get; set; } = null!;

    public decimal GrossPay { get; set; }

    public decimal NetPay { get; set; }

    public decimal? DeductionAmount { get; set; }

    public decimal? BonusAmount { get; set; }

    public decimal? TaxAmount { get; set; }

    public bool IsActive { get; set; }
}