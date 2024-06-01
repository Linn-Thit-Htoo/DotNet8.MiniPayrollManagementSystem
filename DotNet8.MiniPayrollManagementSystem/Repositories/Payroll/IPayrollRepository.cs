using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;

namespace DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll
{
    public interface IPayrollRepository
    {
        Task<IEnumerable<PayrollResponseModel>> GetPayrollListByEmployeeAsync(string employeeCode, string fromDate, string toDate);
        Task<int> CreatePayrollAsync(PayrollRequestModel requestModel);
        Task<int> DeletePayrollAsync(string pId);
        Task<int> UpdatePayrollAsync(PayrollRequestModel requestModel, string pId);
    }
}
