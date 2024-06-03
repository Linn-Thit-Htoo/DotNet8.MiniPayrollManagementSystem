using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.DeleteEmployee;

#region MyRegion

#endregion
public class DeleteEmployeeCommand : IRequest<int>
{
    public long EmployeeId { get; set; }
}