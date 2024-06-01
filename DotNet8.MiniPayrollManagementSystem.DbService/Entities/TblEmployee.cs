namespace DotNet8.MiniPayrollManagementSystem.DbService.Entities;

public partial class TblEmployee
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