using FluentValidation;

namespace DotNet8.MiniPayrollManagementSystem.Api.Validators.Employee;

public class EmployeeValidator : AbstractValidator<EmployeeRequestModel>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.EmployeeName).NotNull().NotEmpty().WithMessage("Employee Name cannot be empty.");
        RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().WithMessage("Email is invalid.");
        RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().MaximumLength(11).WithMessage("Phone Number is invalid.");
        RuleFor(x => x.HireDate).NotNull().NotEmpty().WithMessage("Hire Date cannot be empty.");
        RuleFor(x => x.Position).NotNull().NotEmpty().WithMessage("Position cannot be empty.");
        RuleFor(x => x.Salary).NotNull().NotEmpty().WithMessage("Salary is invalid.");
    }
}