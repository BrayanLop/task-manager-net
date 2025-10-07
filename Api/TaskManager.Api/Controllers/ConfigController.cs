using Microsoft.AspNetCore.Mvc;
using TaskManager.Infrastructure.Interfaces;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private IConfigurationInterface _configurationInterface { get; set; }
        public ConfigController (IEnumerable<IConfigurationInterface> configurationInterfaces)
        {
            _configurationInterface = configurationInterfaces.OfType<EnviromentRepository>().FirstOrDefault();
        }

        [HttpGet]
        public IActionResult Index() 
        {
            return Ok(_configurationInterface.GetValue(""));
        }

    }
}
