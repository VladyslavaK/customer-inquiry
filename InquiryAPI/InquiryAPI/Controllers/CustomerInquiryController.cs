using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace InquiryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInquiryController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return Ok(new Customer());
        }

        [HttpGet("{email}")]
        public ActionResult<Customer> Get(string email)
        {
            return Ok(new Customer());
        }

        [HttpGet]
        public ActionResult<Customer> Get([FromQuery]int id, [FromQuery]string email)
        {
            return Ok(new Customer());
        }

    }
}
