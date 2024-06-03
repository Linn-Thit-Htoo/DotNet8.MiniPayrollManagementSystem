using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.DeletePayroll;

#region DeletePayrollCommand

#endregion
public class DeletePayrollCommand : IRequest<int>
{
    public string PId { get; set; } = null!;
}