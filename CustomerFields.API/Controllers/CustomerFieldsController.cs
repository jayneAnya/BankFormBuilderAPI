using CustomerFields.API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CustomerFields.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerFieldsController : ControllerBase
    {
        private readonly ICustomerFieldService _customerFieldService;

        public CustomerFieldsController(ICustomerFieldService customerFieldService)
        {
            _customerFieldService = customerFieldService;
        }

        [HttpPost("{accountNumber}")]
        public IActionResult GetCustomerFieldsByAccountNumber(string accountNumber)
        {
            var response = _customerFieldService.GetByAccountNumber(accountNumber);

            if (response.ResponseCode == "200")
            {
                return Ok(new
                {
                    response.ResponseCode,
                    response.ResponseDetails,
                    response.ResponseMsg
                });
            }

            return BadRequest(new
            {
                response.ResponseCode,
                response.ResponseMsg
            });
        }

        [HttpGet("{industry}")]
        public IActionResult GetCustomerFieldsByIndustry(string industry)
        {
            var response = _customerFieldService.GetByIndustry(industry);

            if (response.ResponseCode == "200")
            {
                return Ok(new
                {
                    response.ResponseCode,
                    response.ResponseDetails,
                    response.ResponseMsg
                });
            }

            return BadRequest(new
            {
                response.ResponseCode,
                response.ResponseMsg
            });
        }
    }
}