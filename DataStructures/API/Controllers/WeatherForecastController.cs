using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;

namespace API.Controllers
{
    [ApiController]
    [Route("Test/Prueba")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet("{transversal}")]
        public async Task<Movie> Populate([FromRoute] string archivo)
        {
            using (StreamReader reader = new StreamReader(archivo))
            {

            }
                return null;
        }

    }
}
