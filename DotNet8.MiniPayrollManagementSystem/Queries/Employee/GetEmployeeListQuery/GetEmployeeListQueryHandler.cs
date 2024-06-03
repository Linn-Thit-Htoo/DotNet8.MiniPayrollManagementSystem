using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Employee;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Queries.Employee.GetEmployeeListQuery;

#region MyRegion

#endregion
public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, EmployeeListResponseModel>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeListQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeListResponseModel> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetEmployeeListAsync();
    }
}