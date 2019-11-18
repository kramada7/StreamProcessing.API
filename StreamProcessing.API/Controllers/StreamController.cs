using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamProcessing.Services;

namespace StreamProcessing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        private readonly IStreamService _streamService;
        private string characters;
        public StreamController(IStreamService streamService)
        {
            _streamService = streamService;
        }


        
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GetScore()
        {
            //I use StreamReader because the data that I sent from Postman is raw text data
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                characters = await reader.ReadToEndAsync();
                int score = _streamService.CalculateScore(characters);
                if (score >= 0)
                {
                    return Ok(score);
                }

                return BadRequest("Opening and closing curly bracket doesn't match.");
            }

        }
    }
}