using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using Microsoft.AspNetCore.Authentication;

namespace DotNet8.MiniPayrollManagementSystem.Models;

public static class ChangeModel
{
    public static EmployeeModel Change(this TblEmployee dataModel)
    {
        return new EmployeeModel
        {
            EmployeeId = dataModel.EmployeeId,
            EmployeeCode = dataModel.EmployeeCode,
            Email = dataModel.Email,
            EmployeeName = dataModel.EmployeeName,
            HireDate = dataModel.HireDate,
            IsActive = dataModel.IsActive,
            PhoneNumber = dataModel.PhoneNumber,
            Position = dataModel.Position,
            Salary = dataModel.Salary
        };
    }

    public static PayrollModel Change(this TblPayroll dataModel)
    {
        return new PayrollModel
        {
            PId = dataModel.PId,
            BonusAmount = dataModel.BonusAmount,
            DeductionAmount = dataModel.DeductionAmount,
            EmployeeName = dataModel.EmployeeName,
            GrossPay = dataModel.GrossPay,
            NetPay = dataModel.NetPay,
            PayDate = dataModel.PayDate,
            TaxAmount = dataModel.TaxAmount,
            IsAcitve = dataModel.IsActive
        };
    }

    public static TblPayroll Change(this PayrollRequestModel requestModel)
    {
        return new TblPayroll
        {
            PId = Ulid.NewUlid().ToString(),
            EmployeeName = requestModel.EmployeeName,
            BonusAmount = requestModel.BonusAmount,
            DeductionAmount = requestModel.DeductionAmount,
            GrossPay = requestModel.GrossPay,
            NetPay = requestModel.NetPay,
            PayDate = requestModel.PayDate,
            TaxAmount = requestModel.TaxAmount,
            IsActive = true
        };
    }
}