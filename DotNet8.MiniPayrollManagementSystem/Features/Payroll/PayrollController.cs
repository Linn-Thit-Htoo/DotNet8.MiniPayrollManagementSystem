using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace DotNet8.MiniPayrollManagementSystem.Api.Features.Payroll
{
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
        public async Task<IActionResult> GetPayrollListByEmployee(string employeeCode)
        {
            try
            {
                var lst = await _bL_Payroll.GetPayrollByEmployeeAsync(employeeCode);
                return Content(lst);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
