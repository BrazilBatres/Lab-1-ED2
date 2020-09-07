using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIMovieManager.Controllers
{
    [ApiController]
    [Route("api/Pruebas")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{date}")]
        
        public ActionResult Pruebas()
        {
            var result = "hola";
            return Ok(result);
        }

       
    }
}
