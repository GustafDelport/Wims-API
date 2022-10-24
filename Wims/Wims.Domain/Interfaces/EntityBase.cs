namespace Wims.Domain.Interfaces
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual Guid Id { get; } = Guid.NewGuid();
    }
}
