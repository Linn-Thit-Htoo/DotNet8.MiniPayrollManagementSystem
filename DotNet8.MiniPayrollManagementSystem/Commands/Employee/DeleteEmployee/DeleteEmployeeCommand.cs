using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.DeleteEmployee;

#region DeleteEmployeeCommand

#endregion
public class DeleteEmployeeCommand : IRequest<int>
{
    public long EmployeeId { get; set; }
}