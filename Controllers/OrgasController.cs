using Microsoft.AspNetCore.Mvc;
using C_Hero.Models.Entities;
using C_Hero.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C_Hero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgasController : ControllerBase
    {
        private readonly IOrgaService _orgaService;

        public OrgasController(IOrgaService orgaService)
        {
            _orgaService = orgaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrgaModel>>> GetOrgas()
        {
            return Ok(await _orgaService.GetAllOrgasAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrgaModel>> GetOrgaModel(Guid id)
        {
            var orgaModel = await _orgaService.GetOrgaByIdAsync(id);
            if (orgaModel == null)
            {
                return NotFound();
            }
            return Ok(orgaModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrgaModel(Guid id, OrgaModel orgaModel)
        {
            if (id != orgaModel.PK_Orga)
            {
                return BadRequest();
            }

            await _orgaService.UpdateOrgaAsync(orgaModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<OrgaModel>> PostOrgaModel(OrgaModel orgaModel)
        {
            var createdOrga = await _orgaService.CreateOrgaAsync(orgaModel);
            return CreatedAtAction("GetOrgaModel", new { id = createdOrga.PK_Orga }, createdOrga);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgaModel(Guid id)
        {
            await _orgaService.DeleteOrgaAsync(id);
            return NoContent();
        }
    }
}