﻿namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.UpdateEmployee;

#region Update Employee Command Handler

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int> Handle(
        UpdateEmployeeCommand request,
        CancellationToken cancellationToken
    )
    {
        return await _employeeRepository.UpdateEmployeeAsync(
            request.EmployeeRequestModel,
            request.EmployeeId
        );
    }
}

#endregion
