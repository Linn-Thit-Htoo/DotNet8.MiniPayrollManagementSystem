namespace DotNet8.MiniPayrollManagementSystem.Api.Repositories.Employee;

public interface IEmployeeRepository
{
    Task<EmployeeListResponseModel> GetEmployeeListAsync();
    Task<int> CreateEmployeeAsync(EmployeeRequestModel requestModel);
    Task<int> UpdateEmployeeAsync(EmployeeRequestModel requestModel, long id);
    Task<int> DeleteEmployeeAsync(long id);
}