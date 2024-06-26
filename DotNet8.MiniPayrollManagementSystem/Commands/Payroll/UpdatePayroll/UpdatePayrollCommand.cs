namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.UpdatePayroll;

#region Update Payroll Command

public class UpdatePayrollCommand : IRequest<int>
{
    public PayrollRequestModel PayrollRequestModel { get; set; }
    public string PId { get; set; } = null!;
}

#endregion