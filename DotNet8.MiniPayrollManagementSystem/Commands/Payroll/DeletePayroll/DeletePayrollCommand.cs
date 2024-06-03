using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.DeletePayroll;

#region Delete Payroll Command

public class DeletePayrollCommand : IRequest<int>
{
    public string PId { get; set; } = null!;
}
#endregion