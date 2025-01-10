using Microsoft.AspNetCore.Mvc;
using tp_app_back.Interfaces;
using tp_app_back.Models;

namespace tp_app_back.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpPost("{project}")]
        public async Task<IActionResult> CreateProject(Project project)
        {
            var newProject = await _projectService.CreateProjectAsync(project);
            return Ok(newProject);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var getProject = await _projectService.GetProjectByIdAsync(id);
            return Ok(getProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            var getProject = await _projectService.GetProjectByIdAsync(id);

            if (getProject != null)
            {
                return NotFound();
            }
            if (id != project.Id)
            {
                return BadRequest();
            }

            await _projectService.UpdateProjectAsync(project);
            return Ok(getProject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var oldProject = await _projectService.GetProjectByIdAsync(id);
            if (oldProject == null)
            {
                return NotFound();
            }

            await _projectService.DeleteProjectAsync(id);
            return Ok();
        }

    }
}
