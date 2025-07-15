namespace GameLibrary.Domain;

public interface IDomainEntity
{
    public Guid Id { get; }

    public int Version { get; }
}