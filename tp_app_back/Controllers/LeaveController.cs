using Microsoft.AspNetCore.Mvc;
using tp_app_back.Interfaces;
using tp_app_back.Models;

namespace tp_app_back.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeaves()
        {
            var leaves = await _leaveService.GetAllLeavesAsync();
            return Ok(leaves);
        }

        [HttpPost("{leave}")]
        public async Task<IActionResult> CreateLeave(Leave leave)
        {
            var newLeave = await _leaveService.CreateLeaveAsync(leave);
            return Ok(newLeave);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveById(int id)
        {
            var getLeave = await _leaveService.GetLeaveByIdAsync(id);
            return Ok(getLeave);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeave(int id, [FromBody] Leave leave)
        {
            var getLeave = await _leaveService.GetLeaveByIdAsync(id);

            if (getLeave != null)
            {
                return NotFound();
            }
            if (id != leave.Id)
            {
                return BadRequest();
            }

            await _leaveService.UpdateLeaveAsync(leave);
            return Ok(getLeave);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            var oldLeave = await _leaveService.GetLeaveByIdAsync(id);
            if (oldLeave == null)
            {
                return NotFound();
            }

            await _leaveService.DeleteLeaveAsync(id);
            return Ok();
        }

    }
}
