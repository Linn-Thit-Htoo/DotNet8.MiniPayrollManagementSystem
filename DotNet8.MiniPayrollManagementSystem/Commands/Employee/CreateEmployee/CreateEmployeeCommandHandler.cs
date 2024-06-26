using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Employee;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.CreateEmployee;

#region Create Employee Command Handler

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.CreateEmployeeAsync(request.EmployeeRequestModel);
    }
}

#endregion