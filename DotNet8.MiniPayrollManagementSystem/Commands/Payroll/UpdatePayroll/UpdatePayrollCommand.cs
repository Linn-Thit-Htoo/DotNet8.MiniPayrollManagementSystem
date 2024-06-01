using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.UpdatePayroll;

public class UpdatePayrollCommand : IRequest<int>
{
    public PayrollRequestModel PayrollRequestModel { get; set; }
    public string PId { get; set; } = null!;
}