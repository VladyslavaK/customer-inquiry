using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInquiryController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerInquiryController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> Get([FromQuery]long? id, [FromQuery]string email)
        {
            var request = new CustomerInquiryRequest() { CustomerID = id, Email = email };
            if (!TryValidateModel(request))
            {
                return BadRequest(GetErrors());
            }
            
            var result = await _customersRepository.GetCustomersTransactionsAsync(request);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private string GetErrors()
        {
            var errors = new StringBuilder();
            foreach (var modelState in ModelState.Values)
            {
                foreach (var modelError in modelState.Errors)
                {
                    errors.Append(modelError.ErrorMessage);
                    errors.AppendLine();
                }
            }

                return errors.ToString();
        }
    }
}
