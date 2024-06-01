using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.DeletePayroll
{
    public class DeletePayrollCommand : IRequest<int>
    {
        public string PId { get; set; } = null!;
    }
}
