using tp_app_back.Models;

namespace tp_app_back.Interfaces
{
    public interface ILeaveService
    {
        public Task<List<Leave>> GetAllLeavesAsync();
        public Task<Leave> CreateLeaveAsync(Leave employee);
        public Task<Leave> GetLeaveByIdAsync(int id);
        public Task<Leave> UpdateLeaveAsync(Leave employee);
        public Task<bool> DeleteLeaveAsync(int id);

    }
}
