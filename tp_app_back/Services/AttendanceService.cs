using tp_app_back.Interfaces;
using tp_app_back.Models;

namespace tp_app_back.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IGenericService<Attendance> _genericService;

        public AttendanceService(IGenericService<Attendance> genericService)
        {
            _genericService = genericService;
        }

        public async Task<List<Attendance>> GetAllAttendancesAsync()
        {
            var attendances = await _genericService.GetAllAsync();
            return attendances;
        }

        public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
        {
            var newAttendance = await _genericService.CreateAsync(attendance);
            return newAttendance;
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            var getAttendance = await _genericService.GetByIdAsync(id);
            return getAttendance;
        }

        public async Task<Attendance> UpdateAttendanceAsync(Attendance attendance)
        {
            var updateAttendance = await _genericService.UpdateAsync(attendance);
            return updateAttendance;
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var oldAttendance = await _genericService.DeleteAsync(id);
            return oldAttendance;
        }

    }
}
