using System.Net;
using Application.Model;
using Application.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : ControllerBase
    {
        private readonly ILogger<RobotController> _logger;
        private readonly IRobotService _robotService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class.
        /// </summary>
        /// <param name="robotService">The robot service.</param>
        /// <param name="logger">The logger.</param>
        public RobotController(IRobotService robotService,
            ILogger<RobotController> logger)
        {
            _logger = logger;
            _robotService = robotService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Health check....");
            return Ok("This is Just Test Message");
        }

        /// <summary>
        /// Creates the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(OutputResponseJson), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost]
        public IActionResult Create([FromBody] InputRequestJson request)
        {
            _logger.LogInformation("New request");
            _robotService.ParseRequst(request);
            var output = new OutputResponseJson(_robotService.Robot);

            return Ok(output);
        }
    }
}