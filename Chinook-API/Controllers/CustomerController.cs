using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinook_API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/customer/country
        [HttpGet("{country}")]
        public IActionResult GetByCountry(string country)
        {
            var repo = new CustomerRepository();
            var customers = repo.GetByCountry(country);

            if (!customers.Any())
                return NotFound();

            return Ok(customers);
        }

        [HttpGet("country_exception/{country}")]
        public IActionResult GetByAllCountriesExcept(string country)
        {
            var repo = new CustomerRepository();
            var customers = repo.GetByAllCountriesExcept(country);

            if (!customers.Any())
                return NotFound();

            return Ok(customers);
        }
    }
}
