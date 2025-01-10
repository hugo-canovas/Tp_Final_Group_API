using tp_app_back.Models;

namespace tp_app_back.Interfaces
{
    public interface IProjectService
    {
        public Task<List<Project>> GetAllProjectsAsync();
        public Task<Project> CreateProjectAsync(Project project);
        public Task<Project> GetProjectByIdAsync(int id);
        public Task<Project> UpdateProjectAsync(Project project);
        public Task<bool> DeleteProjectAsync(int id);
    }
}
