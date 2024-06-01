using DotNet8.MiniPayrollManagementSystem.Models.Setup.Employee;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Employee;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : BaseController
{
    private readonly BL_Employee _bL_Employee;

    public EmployeeController(BL_Employee bL_Employee)
    {
        _bL_Employee = bL_Employee;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            var lst = await _bL_Employee.GetEmployeeListAsync();
            return Content(lst);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequestModel requestModel)
    {
        try
        {
            int result = await _bL_Employee.CreateEmployeeAsync(requestModel);
            return result > 0 ? Created("Employee Created.") : BadRequest("Creating Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(long id)
    {
        try
        {
            int result = await _bL_Employee.DeleteEmployeeAsync(id);
            return result > 0 ? Accepted("Employee Deleted.") : BadRequest("Deleting Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }
}
