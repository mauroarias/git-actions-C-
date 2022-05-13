using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPoc.Model;

namespace ProjectPoc.Controllers;

[ApiController]
[Route("/project")]
public class ProjectController
{
    private readonly GenesisClient _genesisClient;
    private readonly ProjectContext _projectContext;
    private readonly ILogger<ProjectController> _logger;

    public ProjectController(ProjectContext projectContext, ILogger<ProjectController> logger, IConfiguration configuration)
    {
        var host = configuration["genesis:host"];
        var port = configuration["genesis:port"];
        _genesisClient = GenesisClient.BuildClient($"{host}:{port}");
        _projectContext = projectContext;
        _logger = logger;
    }


    [HttpPost]
    public async Task<IResult> Post(Project project)
    {
        _logger.LogInformation("getting project '[{project}]'", project);
        project.id = Guid.NewGuid();
        project.license = _genesisClient.GetUser(project.licenseId).Result;
        _projectContext.Add(project);
        await _projectContext.SaveChangesAsync();
        return Results.Created($"/project/{project.id}", project);
    }

    [HttpGet]
    public async Task<IEnumerable<Project>> GetAll()
    {
        return await _projectContext.Projects.Include(a => a.license).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(Guid id)
    {
        return await _projectContext.Projects.Include(a => a.license).FirstOrDefaultAsync(i => i.id == id) is Project project ? Results.Ok(project) : Results.NotFound();
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