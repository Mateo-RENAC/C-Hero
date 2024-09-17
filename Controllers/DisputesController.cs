// DisputesController.cs
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
    public class DisputesController : ControllerBase
    {
        private readonly IDisputeService _disputeService;

        public DisputesController(IDisputeService disputeService)
        {
            _disputeService = disputeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisputeModel>>> GetDisputes()
        {
            return Ok(await _disputeService.GetAllDisputesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DisputeModel>> GetDisputeModel(Guid id)
        {
            var disputeModel = await _disputeService.GetDisputeByIdAsync(id);
            if (disputeModel == null)
            {
                return NotFound();
            }
            return Ok(disputeModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisputeModel(Guid id, DisputeModel disputeModel)
        {
            if (id != disputeModel.PK_Dispute)
            {
                return BadRequest();
            }

            await _disputeService.UpdateDisputeAsync(disputeModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<DisputeModel>> PostDisputeModel(DisputeModel disputeModel)
        {
            var createdDispute = await _disputeService.CreateDisputeAsync(disputeModel);
            return CreatedAtAction("GetDisputeModel", new { id = createdDispute.PK_Dispute }, createdDispute);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisputeModel(Guid id)
        {
            await _disputeService.DeleteDisputeAsync(id);
            return NoContent();
        }
    }
}

