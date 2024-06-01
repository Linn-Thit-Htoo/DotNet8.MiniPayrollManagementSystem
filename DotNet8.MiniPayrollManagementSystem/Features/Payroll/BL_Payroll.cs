using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;

namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Payroll
{
    public class BL_Payroll
    {
        private readonly DA_Payroll _dA_Payroll;

        public BL_Payroll(DA_Payroll dA_Payroll)
        {
            _dA_Payroll = dA_Payroll;
        }

        public async Task<PayrollListResponseModel> GetPayrollByEmployeeAsync(string employeeCode)
        {
            if (string.IsNullOrEmpty(employeeCode))
                throw new Exception("Employee Code cannot be empty.");

            return await _dA_Payroll.GetPayrollByEmployeeAsync(employeeCode);
        }
    }
}
