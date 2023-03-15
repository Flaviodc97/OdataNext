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

        

        [EnableQuery]
        public ActionResult Get() 
        {
           return Ok();
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