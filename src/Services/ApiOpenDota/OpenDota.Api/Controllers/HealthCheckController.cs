using Microsoft.AspNetCore.Mvc;
using OpenDota.Api.ServicesApi;
using System.Net;
using System.Threading.Tasks;

namespace OpenDota.Api.Controllers
{

    [ApiController]
    [Route("api/v1")]
    public class HealthCheckController : ControllerBase
    {
        private readonly DotaHealthCheckService _service;

        public HealthCheckController()
        {
            _service = new DotaHealthCheckService();
        }

        //Implementar logica
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [Route("HealthCheck")]
        public ActionResult HealthCheck()
        {
            return Ok(string.Empty);
        }


        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [Route("ExternalHealthCheck")]
        public async Task<ActionResult> GetAllHeroes()
        {
            var check = await _service.HealthCheck();

            if (check == false) return StatusCode(500);

            return Ok(string.Empty);
        }
    }
}
