using GenesisMock.Model;
using Microsoft.EntityFrameworkCore;

namespace ProjectPoc.Model;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options): base(options) {

    }
    public DbSet<Project> Projects => Set<Project>();
}