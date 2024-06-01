using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using FluentValidation;

namespace DotNet8.MiniPayrollManagementSystem.Api.Validators.Payroll;

public class PayrollValidator : AbstractValidator<PayrollRequestModel>
{
    public PayrollValidator()
    {
        RuleFor(x => x.EmployeeName).NotEmpty().NotNull().WithMessage("Employee Name cannot be empty.");
        RuleFor(x => x.PayDate).NotEmpty().NotNull().WithMessage("Pay Date cannot be empty.");
        RuleFor(x => x.GrossPay).NotEmpty().NotNull().WithMessage("Gross Pay cannot be empty.");
        RuleFor(x => x.NetPay).NotEmpty().NotNull().WithMessage("Net Pay cannot be empty.");
        //RuleFor(x => x.DeductionAmount).NotEmpty().NotNull().WithMessage("Deduction Amount cannot be empty.");
        //RuleFor(x => x.BonusAmount).NotEmpty().NotNull().WithMessage("Bonus Amount cannot be empty.");
        //RuleFor(x => x.TaxAmount).NotEmpty().NotNull().WithMessage("Tax Amount cannot be empty.");
    }
}