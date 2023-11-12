namespace DevFreela.Infrastructure.Persistence;

public interface IUnitOfWork
{
   Task SaveChangesAsync();
}