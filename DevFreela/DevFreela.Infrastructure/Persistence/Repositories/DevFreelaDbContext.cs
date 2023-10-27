using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence.Repositories;

/// <summary>
/// it's works as Database.
/// </summary>
public class DevFreelaDbContext
{
    public DevFreelaDbContext()
    {
        Projects = new List<Project>()
        {
            new Project("Meu Projeto ASPNET Core",
                "Projeto", "Minha Descrição", Guid.NewGuid(),
                Guid.NewGuid(), totalCost:12.0M)
        };
        Skills = new List<Skill>()
        {
            new Skill("Desenvolvedor C#"),
            new Skill("Cozinhar")
        };
        User = new List<User>()
        {
            new User("Mayardes Oliveira", "mayardesoliveira@gmail.com", DateTime.Now),
            new User("Robert C Martin", "robertmartin@gmail.com", DateTime.Now)
        };
    }
    public List<Project> Projects { get; set; }
    public List<Skill> Skills { get; set; }
    public List<User> User { get; set; }
    public List<ProjectComment> ProjectComments { get; set; }
}