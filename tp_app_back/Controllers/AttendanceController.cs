using Microsoft.AspNetCore.Mvc;
using tp_app_back.Interfaces;
using tp_app_back.Models;

namespace tp_app_back.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        [HttpPost("{attendance}")]
        public async Task<IActionResult> CreateAttendance(Attendance attendance)
        {
            var newAttendance = await _attendanceService.CreateAttendanceAsync(attendance);
            return Ok(newAttendance);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            var getAttendance = await _attendanceService.GetAttendanceByIdAsync(id);
            return Ok(getAttendance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, [FromBody] Attendance attendance)
        {
            var getAttendance = await _attendanceService.GetAttendanceByIdAsync(id);

            if (getAttendance != null)
            {
                return NotFound();
            }
            if (id != attendance.Id)
            {
                return BadRequest();
            }

            await _attendanceService.UpdateAttendanceAsync(attendance);
            return Ok(getAttendance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var oldAttendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (oldAttendance == null)
            {
                return NotFound();
            }

            await _attendanceService.DeleteAttendanceAsync(id);
            return Ok();
        }

    }
}
