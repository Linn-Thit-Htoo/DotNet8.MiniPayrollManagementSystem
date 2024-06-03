using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.DeletePayroll;

#region MyRegion

#endregion
public class DeletePayrollCommandHandler : IRequestHandler<DeletePayrollCommand, int>
{
    private readonly IPayrollRepository _payrollRepository;

    public DeletePayrollCommandHandler(IPayrollRepository payrollRepository)
    {
        _payrollRepository = payrollRepository;
    }

    public async Task<int> Handle(DeletePayrollCommand request, CancellationToken cancellationToken)
    {
        return await _payrollRepository.DeletePayrollAsync(request.PId);
    }
}