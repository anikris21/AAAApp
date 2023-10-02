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
                s => s
                //.Index("users")
                .Query(q => q.Term(t => t.Name, id) || 
                q.Match(m => m.Field(f => f.Name).Query(id))));
            return response?.Documents?.FirstOrDefault();
        }

        // GET: ElasticController/Create Task<ActionResult<string>>
        [HttpPost]
        public async Task<ActionResult<string>> Create(User user)
        {
            var response = await _elasticClient.IndexAsync<User>(user, i => i.Index("users"));
            return response.Id;
            
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
