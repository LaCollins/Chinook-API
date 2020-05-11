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

        [HttpGet("invoice/country/{country}")]
        public IActionResult GetInvoiceByCountry(string country)
        {
            var repo = new CustomerRepository();
            var invoices = repo.GetInvoiceByCountry(country);

            if (!invoices.Any())
                return NotFound();

            return Ok(invoices);
        }

        [HttpGet("employee/agent")]
        public IActionResult GetSalesAgents()
        {
            var repo = new EmployeeRepository();
            var agents = repo.GetSalesAgents();

            if (!agents.Any())
                return NotFound();

            return Ok(agents);
        }

        [HttpGet("billingCountries")]
        public IActionResult GetUniqueCountries()
        {
            var repo = new CustomerRepository();
            var countries = repo.GetUniqueCountries();

            if (!countries.Any())
                return NotFound();

            return Ok(countries);
        }
    }
}
