namespace DotNet8.MiniPayrollManagementSystem.Api.Commands.Employee.CreateEmployee;

#region Create Employee Command

public class CreateEmployeeCommand : IRequest<int>
{
    public EmployeeRequestModel EmployeeRequestModel { get; set; }
}

#endregion