using tp_app_back.Interfaces;
using tp_app_back.Models;

namespace tp_app_back.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly IGenericService<Leave> _genericService;

        public LeaveService(IGenericService<Leave> genericService)
        {
            _genericService = genericService;
        }

        public async Task<List<Leave>> GetAllLeavesAsync()
        {
            var leaves = await _genericService.GetAllAsync();
            return leaves;
        }

        public async Task<Leave> CreateLeaveAsync(Leave leave)
        {
            var newLeave = await _genericService.CreateAsync(leave);
            return newLeave;
        }

        public async Task<Leave> GetLeaveByIdAsync(int id)
        {
            var getLeave = await _genericService.GetByIdAsync(id);
            return getLeave;
        }

        public async Task<Leave> UpdateLeaveAsync(Leave leave)
        {
            var updateLeave = await _genericService.UpdateAsync(leave);
            return updateLeave;
        }

        public async Task<bool> DeleteLeaveAsync(int id)
        {
            var oldLeave = await _genericService.DeleteAsync(id);
            return oldLeave;
        }

    }
}
