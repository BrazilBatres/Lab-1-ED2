using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.VisualBasic;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class Movies : ControllerBase
    {

        [HttpPost]
        public async Task<List<Movie>> Populate([FromForm] IFormFile file)
        {
            List<Movie> result = new List<Movie>();
            using var Memory = new MemoryStream();
            await file.CopyToAsync(Memory);
            var contenido = Encoding.ASCII.GetString(Memory.ToArray());

            return result;
        }

    }
}
