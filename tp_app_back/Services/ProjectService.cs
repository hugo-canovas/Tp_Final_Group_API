using tp_app_back.Interfaces;
using tp_app_back.Models;

namespace tp_app_back.Services
{
    public class ProjectService : IProjectService
    {
    
    private readonly IGenericService<Project> _genericService;

    public ProjectService(IGenericService<Project> genericService)
    {
        _genericService = genericService;
    }

    public async Task<List<Project>> GetAllProjectsAsync()
    {
        var projects = await _genericService.GetAllAsync();
        return projects;
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        var newProject = await _genericService.CreateAsync(project);
        return newProject;
    }

    public async Task<Project> GetProjectByIdAsync(int id)
    {
        var getProject = await _genericService.GetByIdAsync(id);
        return getProject;
    }

    public async Task<Project> UpdateProjectAsync(Project project)
    {
        var updateProject = await _genericService.UpdateAsync(project);
        return updateProject;
    }

    public async Task<bool> DeleteProjectAsync(int id)
    {
        var oldProject = await _genericService.DeleteAsync(id);
        return oldProject;
    }
}
}
