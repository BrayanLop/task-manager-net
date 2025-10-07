using Microsoft.AspNetCore.Mvc;
using TaskManager.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        public IConfigurationInterface _configurationInterface { get; set; }
        public ICacheRepository _cacheRepository { get; set; }

        public TasksController(IConfigurationInterface configurationInterface, ICacheRepository cacheRepository)
        {
            _configurationInterface = configurationInterface;
            _cacheRepository = cacheRepository;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TasksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _cacheRepository.Set("", "");
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
