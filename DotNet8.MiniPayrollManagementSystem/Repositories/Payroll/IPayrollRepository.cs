using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;

namespace DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll
{
    public interface IPayrollRepository
    {
        Task<PayrollListResponseModel> GetPayrollByEmployeeAsync(string employeeCode);
    }
}
