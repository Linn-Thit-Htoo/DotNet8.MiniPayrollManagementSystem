using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.CreatePayroll;

#region CreatePayrollCommandHandler

#endregion
public class CreatePayrollCommandHandler : IRequestHandler<CreatePayrollCommand, int>
{
    private readonly IPayrollRepository _payrollRepository;

    public CreatePayrollCommandHandler(IPayrollRepository payrollRepository)
    {
        _payrollRepository = payrollRepository;
    }

    public async Task<int> Handle(CreatePayrollCommand request, CancellationToken cancellationToken)
    {
        return await _payrollRepository.CreatePayrollAsync(request.PayrollRequestModel);
    }
}