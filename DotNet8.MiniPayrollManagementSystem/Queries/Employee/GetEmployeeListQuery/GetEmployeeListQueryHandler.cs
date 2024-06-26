﻿namespace DotNet8.MiniPayrollManagementSystem.Api.Queries.Employee.GetEmployeeListQuery;

#region Get Employee List Query Handler

public class GetEmployeeListQueryHandler
    : IRequestHandler<GetEmployeeListQuery, EmployeeListResponseModel>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeListQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeListResponseModel> Handle(
        GetEmployeeListQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _employeeRepository.GetEmployeeListAsync();
    }
}

#endregion
