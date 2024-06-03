using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.UpdatePayroll;

#region Update Payroll Command Handler

#endregion
public class UpdatePayrollCommandHandler : IRequestHandler<UpdatePayrollCommand, int>
{
    private readonly IPayrollRepository _payrollRepository;

    public UpdatePayrollCommandHandler(IPayrollRepository payrollRepository)
    {
        _payrollRepository = payrollRepository;
    }

    public async Task<int> Handle(UpdatePayrollCommand request, CancellationToken cancellationToken)
    {
        return await _payrollRepository.UpdatePayrollAsync(request.PayrollRequestModel, request.PId);
    }
}