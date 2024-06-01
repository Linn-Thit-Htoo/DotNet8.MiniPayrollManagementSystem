using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Queries.Employee.GetEmployeeListQuery
{
    public class GetEmployeeListQuery : IRequest<EmployeeListResponseModel>
    {
    }
}
