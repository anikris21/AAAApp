using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace Elasticsearch.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElasticController : ControllerBase
    {


        readonly IElasticClient _elasticClient;
        public ElasticController(IElasticClient elasticClient) {
            _elasticClient = elasticClient;
        
        }


        // GET: ElasticController
        // ActionResult<string> return "test";
        [HttpGet]
        public ActionResult<string> Index()
        {
            //return "test";
            return "test";
        }


        [HttpGet("{id}")]
        // Task<ActionResult<User>> response?.Documents?.FirstOrDefault()
        public async Task<ActionResult<User>> Details(string id)
        {
            var response = await _elasticClient.SearchAsync<User>(
                s => s.Query(q => q.Term(t => t.Name, id) || 
                q.Match(m => m.Field(f => f.Name).Query(id))));
            return response?.Documents?.FirstOrDefault();
        }

        // GET: ElasticController/Create
        [HttpPost]
        public ActionResult<string> Create(User user)
        {
            return "test";
        }



        // GET: ElasticController/Edit/5
        [HttpPut]
        public ActionResult<string> Edit(int id)
        {
            return "test";
        }


        // GET: ElasticController/Delete/5
        [HttpDelete]
        public ActionResult<string> Delete(int id)
        {
            return "test";
        }

        
    }
}
