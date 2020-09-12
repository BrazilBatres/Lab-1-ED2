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
using System.Text.Json;
using System.Text.Json.Serialization;
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
            string contenido = Encoding.ASCII.GetString(Memory.ToArray());

            result = JsonSerializer.Deserialize<List<Movie>>(contenido);
           

            return result;
        }


        public static Movie ConvertToJson(string contenido)
        {
            return JsonSerializer.Deserialize<Movie>(contenido, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });

        }

    }
}
