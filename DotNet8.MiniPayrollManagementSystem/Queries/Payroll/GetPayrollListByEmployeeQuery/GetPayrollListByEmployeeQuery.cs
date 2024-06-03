﻿using DotNet8.MiniPayrollManagementSystem.Models.Setup.Payroll;
using MediatR;

namespace DotNet8.MiniPayrollManagementSystem.Api.Queries.Payroll.GetPayrollListByEmployeeQuery;

#region MyRegion

#endregion
public class GetPayrollListByEmployeeQuery : IRequest<IEnumerable<PayrollResponseModel>>
{
    public string EmployeeCode { get; set; } = null!;
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
}