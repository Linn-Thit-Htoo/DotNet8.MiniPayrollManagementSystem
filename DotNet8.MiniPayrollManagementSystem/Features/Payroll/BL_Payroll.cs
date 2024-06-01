using DotNet8.MiniPayrollManagementSystem.Api.Validators.Payroll;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text;

namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Payroll
{
    public class BL_Payroll
    {
        private readonly DA_Payroll _dA_Payroll;
        private readonly PayrollValidator _payrollValidator;

        public BL_Payroll(DA_Payroll dA_Payroll, PayrollValidator payrollValidator)
        {
            _dA_Payroll = dA_Payroll;
            this._payrollValidator = payrollValidator;
        }

        public async Task<IEnumerable<PayrollResponseModel>> GetPayrollByEmployeeAsync(string employeeCode, string? fromDate = "", string? toDate = "")
        {
            if (string.IsNullOrEmpty(employeeCode))
                throw new Exception("Employee Code cannot be empty.");

            return await _dA_Payroll.GetPayrollByEmployeeAsync(employeeCode, fromDate, toDate);
        }

        public async Task<int> CreatePayrollAsync(PayrollRequestModel requestModel)
        {
            ValidationResult validationResult = await _payrollValidator.ValidateAsync(requestModel);
            StringBuilder errors = new();

            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(err => errors.AppendLine(err.ErrorMessage));
                throw new Exception(errors.ToString());
            }

            return await _dA_Payroll.CreatePayrollAsync(requestModel);
        }

        public async Task<int> DeletePayrollAsync(string pId)
        {
            if (string.IsNullOrEmpty(pId))
                throw new Exception("Id cannot be empty.");

            return await _dA_Payroll.DeletePayrollAsync(pId);
        }
    }
}
