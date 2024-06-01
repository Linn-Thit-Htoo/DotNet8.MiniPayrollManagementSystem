using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniPayrollManagementSystem.Models
{
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
                PhonNumber = dataModel.PhonNumber,
                Position = dataModel.Position,
                Salary = dataModel.Salary
            };
        }
    }
}
