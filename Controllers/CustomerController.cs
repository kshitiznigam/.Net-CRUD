using System;
using Microsoft.AspNetCore.Mvc;
using CRUD.Models;


namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly YourDbContext _dbContext; // Inject your database context

        public CustomerController(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetCustomers")]
        public IActionResult GetCustomers()
        {
            var customers = _dbContext.Customers.ToList();
            return Ok(customers);
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // _dbContext.Customers.Add(customer);
                // _dbContext.SaveChanges();
                 Console.WriteLine(customer.CustomerName);
                  _dbContext.Customers.Add(customer);
                 _dbContext.SaveChanges();
                return Ok(customer);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("EditCustomer/{customerId}")]
        public IActionResult EditCustomer(int customerId, Customer customer)
        {
            var existingCustomer = _dbContext.Customers.Find(customerId);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.Email = customer.Email;
            existingCustomer.ContactNo = customer.ContactNo;
            existingCustomer.LastOrderDate = customer.LastOrderDate;

            _dbContext.SaveChanges();
            return Ok(existingCustomer);
        }

        [HttpDelete("DeleteCustomer/{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            var existingCustomer = _dbContext.Customers.Find(customerId);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(existingCustomer);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
