using Microsoft.AspNetCore.Mvc;
using OpenDota.Api.Entities;
using OpenDota.Api.ServicesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OpenDota.Api.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class DotaSearchController : ControllerBase
    {
        private readonly DotaSearchService _service;

        public DotaSearchController()
        {
            _service = new DotaSearchService();
        }

        //Implementar logica
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlayerRank>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PlayerRank>>> GetAllPlayersByRank()
        {
            var playersRank = await _service.GetPlayersRank();

            if (playersRank == null) 
                return NotFound();

            return Ok(playersRank);
        }
    }
}
