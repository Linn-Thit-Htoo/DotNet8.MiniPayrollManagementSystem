﻿namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.DeleteEmployee;

#region Delete Employee Command Handler

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int> Handle(
        DeleteEmployeeCommand request,
        CancellationToken cancellationToken
    )
    {
        return await _employeeRepository.DeleteEmployeeAsync(request.EmployeeId);
    }
}

#endregion
