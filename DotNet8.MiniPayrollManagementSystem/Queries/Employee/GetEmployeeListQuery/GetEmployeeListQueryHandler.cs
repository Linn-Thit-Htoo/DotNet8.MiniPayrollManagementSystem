using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using DotNet8.MiniPayrollManagementSystem.Repositories.Employee;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Queries.Employee.GetEmployeeListQuery
{
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
}
