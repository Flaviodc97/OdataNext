using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace OdataNext.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ODataController
    {
        public CustomersController()
        {
           
        }

        private static Random random = new Random();




    }
}