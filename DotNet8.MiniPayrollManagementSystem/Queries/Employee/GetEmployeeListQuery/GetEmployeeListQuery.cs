using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Queries.Employee.GetEmployeeListQuery
{
    public class GetEmployeeListQuery : IRequest<EmployeeListResponseModel>
    {
    }
}