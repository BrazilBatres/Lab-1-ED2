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
using DataStructures;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class Movies : ControllerBase
    {
        
        [HttpPost("Populate")]
        public async Task<string> Populate([FromForm] IFormFile file)
        {
            List<Movie> result = new List<Movie>();
            using var Memory = new MemoryStream();
            await file.CopyToAsync(Memory);
            

            try
            {
                string contenido = Encoding.ASCII.GetString(Memory.ToArray());

                result = JsonSerializer.Deserialize<List<Movie>>(contenido);
                foreach (var movie in result)
                {
                    Data.tree.Insert(movie);
                }
                return "Elementos agregados al árbol correctamente";
            }
            catch (Exception)
            {
                return "Error en el ingreso de datos";
            }
        }

        [HttpPost("Order")]
        public string SetOrder([FromForm] IFormFile file)
        {
            var Memory = new MemoryStream();
            file.CopyToAsync(Memory);
            string contenido = Encoding.ASCII.GetString(Memory.ToArray());
            try
            {
                Order result = JsonSerializer.Deserialize<Order>(contenido);
                if(result.order <2)
                {
                    Data.tree = new MultiPathTree<Movie>(result.order);  
                    return "Grado del árbol inválido, se utilizará grado 2. Arbol generado correctamente";
                }
                else
                {
                    Data.tree = new MultiPathTree<Movie>(result.order);
                    return "Grado " + result.order + " aceptado. Arbol generado"; 
                }
            }
            catch (Exception)
            {
                return "Fallo crítico al generar el árbol";
                
            }
        }
        
        [HttpGet("InOrder")]
        public IActionResult InOrder()
        {
            List<Movie> recorrido = new List<Movie>();
            Data.tree.InOrder(recorrido);
            JsonSerializer.Serialize(recorrido);
            return Ok(recorrido);
        }

        [HttpGet("PreOrder")]
        public IActionResult PreOrder()
        {
            List<Movie> recorrido = new List<Movie>();
            Data.tree.PreOrder(recorrido);
            JsonSerializer.Serialize(recorrido);
            return Ok(recorrido);
        }
        [HttpGet("PostOrder")]
        public IActionResult PostOrder()
        {
            List<Movie> recorrido = new List<Movie>();
            Data.tree.PostOrder(recorrido);
            JsonSerializer.Serialize(recorrido);
            return Ok(recorrido);
        }

        [HttpGet("index")]
        public string Welcome()
        {
            return "Esperando entrada Postman";
        }
    }
}
