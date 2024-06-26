﻿namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Payroll.CreatePayroll;

#region Create Payroll Command Handler

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

#endregion
