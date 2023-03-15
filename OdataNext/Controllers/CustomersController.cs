using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using OdataNext.Data;
using OdataNext.Models;

namespace OdataNext.Controllers
{
    
    public class CustomersController : ODataController
    {

        private readonly OdataDbContextcs _context;
        public CustomersController(OdataDbContextcs context)
        {
            _context = context;
           
        }

        
        public ActionResult Post([FromBody] Customer customer) 
        {
            _context.Add(customer);
            _context.SaveChanges();
            return Created(customer);
            
        }

        public ActionResult Put([FromRoute] int key, [FromBody] Customer updatedCustomer)
        {
            var customer = _context.Customer.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = updatedCustomer.Name;
            customer.Surname = updatedCustomer.Surname;
            customer.Address = updatedCustomer.Address;

            _context.SaveChanges();

            return Updated(customer);
        }

        public ActionResult Delete([FromRoute] int key)
        {
            var customer = _context.Customer.SingleOrDefault(d => d.Id == key);

            if (customer != null)
            {
                _context.Customer.Remove(customer);
            }

            _context.SaveChanges();

            return NoContent();
        }

        

        [EnableQuery]
        public async Task<ActionResult> Get() 
        {
           var allCustomers = await _context.Customer.Include(c => c.Orders).ToListAsync();
           return Ok(allCustomers);
        }

        [EnableQuery]
        public async  Task<ActionResult> Get([FromRoute] int key)
        {
            var item = await _context.Customer.FirstOrDefaultAsync(customer => customer.Id == key);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


    }
}