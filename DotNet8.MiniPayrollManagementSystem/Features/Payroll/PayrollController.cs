namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Payroll;

[Route("api/[controller]")]
[ApiController]
public class PayrollController : BaseController
{
    private readonly BL_Payroll _bL_Payroll;

    public PayrollController(BL_Payroll bL_Payroll)
    {
        _bL_Payroll = bL_Payroll;
    }

    [HttpGet]
    public async Task<IActionResult> GetPayrollListByEmployee(
        string employeeCode,
        string? fromDate = "",
        string? toDate = ""
    )
    {
        try
        {
            var lst = await _bL_Payroll.GetPayrollByEmployeeAsync(employeeCode, fromDate, toDate);
            return Content(lst);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayroll([FromBody] PayrollRequestModel requestModel)
    {
        try
        {
            int result = await _bL_Payroll.CreatePayrollAsync(requestModel);
            return result > 0 ? Created("Payroll Created.") : BadRequest("Creating Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPatch("{pId}")]
    public async Task<IActionResult> UpdatePayroll(
        [FromBody] PayrollRequestModel requestModel,
        string pId
    )
    {
        try
        {
            int result = await _bL_Payroll.UpdatePayrollAsync(requestModel, pId);
            return result > 0 ? Accepted("Payroll Updated.") : BadRequest("Updating Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayroll(string id)
    {
        try
        {
            int result = await _bL_Payroll.DeletePayrollAsync(id);
            return result > 0 ? Accepted("Payroll Deleted.") : BadRequest("Deleting Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }
}
