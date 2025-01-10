using tp_app_back.Models;

namespace tp_app_back.Interfaces
{
    public interface IAttendanceService
    {
        public Task<List<Attendance>> GetAllAttendancesAsync();
        public Task<Attendance> CreateAttendanceAsync(Attendance attendance);
        public Task<Attendance> GetAttendanceByIdAsync(int id);
        public Task<Attendance> UpdateAttendanceAsync(Attendance attendance);
        public Task<bool> DeleteAttendanceAsync(int id);
    }
}
