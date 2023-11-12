namespace DevFreela.Core.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    protected BaseEntity()
    {
        
    }
}