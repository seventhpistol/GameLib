namespace GameLibrary.Domain;

public class DomainEntity(Guid id) : IDomainEntity
{
    public Guid Id { get; } = id;
    public int Version { get; set;  }
}