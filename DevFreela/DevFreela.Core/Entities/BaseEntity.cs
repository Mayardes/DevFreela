namespace DevFreela.Core.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }

    protected BaseEntity()
    {
        
    }
}