using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        //IOptions<ApiOptions>
        public NamesController(IOptions<ApiOptions> options) {
            Console.WriteLine(options.Value.Url);
            Console.WriteLine(options.Value.ApiKey);

        }
        // GET: api/<NamesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NamesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("autheticate")] 
        public IActionResult Authenticate([FromBody] UserCred userCred) { 
            return Ok();
        }

        // POST api/<NamesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
