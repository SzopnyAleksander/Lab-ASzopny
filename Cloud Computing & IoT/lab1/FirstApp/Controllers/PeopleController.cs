using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var people = new List<Models.Person>
            {
                new Models.Person
                {
                    FirstName = "Aleksander",
                    LastName = "Szopny",
                    Id = 1
                }
            };
            return Ok(people);
        }
        
    }
}
