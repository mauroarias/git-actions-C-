using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPoc.Model;

namespace ProjectPoc;

[ApiController]
[Route("/project")]
public class ProjectController
{
    private readonly GenesisClient _genesisClient;
    private readonly ProjectContext _projectContext;
    private readonly ILogger<ProjectController> _logger;

    public ProjectController(ProjectContext projectContext, GenesisClient genesisClient, ILogger<ProjectController> logger)
    {
        _genesisClient = genesisClient;
        _projectContext = projectContext;
        _logger = logger;
    }
    
    [HttpPost]
    public async Task<IResult> Post(Project project)
    {
        _logger.LogInformation("getting project '[{project}]'", project);
        project.id = Guid.NewGuid();
        var license = _genesisClient.GetUser(project.licenseId).Result;
        project.licenseEmail = license.email;
        project.licenseName = license.name;
        project.licenseExpiresAt = license.expires_at;
        _projectContext.Add(project);
        await _projectContext.SaveChangesAsync();
        return Results.Created($"/project/{project.id}", project);
    }

    [HttpGet]
    public async Task<IEnumerable<Project>> GetAll()
    {
        return await _projectContext.Projects.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(Guid id)
    {
        return await _projectContext.Projects.FirstOrDefaultAsync(i => i.id == id) is Project project ? Results.Ok(project) : Results.NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(Guid id)
    {
        var project = await _projectContext.Projects.FindAsync(id);
        if (project is not null)
        {
            _projectContext.Projects.Remove(project);
            await _projectContext.SaveChangesAsync();
        }
        return Results.NoContent();
    }

}