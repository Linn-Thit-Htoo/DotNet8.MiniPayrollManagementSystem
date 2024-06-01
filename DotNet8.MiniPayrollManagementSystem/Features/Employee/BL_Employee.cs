using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;

namespace DotNet8.MiniPayrollManagementSystem.Features.Employee
{
    public class BL_Employee
    {
        private readonly DA_Employee _dA_Employee;

        public BL_Employee(DA_Employee dA_Employee)
        {
            _dA_Employee = dA_Employee;
        }

        public async Task<EmployeeListResponseModel> GetEmployeeListAsync()
        {
            return await _dA_Employee.GetEmployeeListAsync();
        }
    }
}