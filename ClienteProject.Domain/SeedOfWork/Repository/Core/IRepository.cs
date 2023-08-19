namespace ClienteProject.Domain.SeedOfWork.Repository.Core;
public interface IRepository<TAggregate> : IDisposable where TAggregate : AggregateRoot
{
    public Task Insert(TAggregate aggregate, CancellationToken cancellationToken);
    public Task<TAggregate> Get(Guid id, CancellationToken cancellationToken);
    public Task Delete(TAggregate aggregate, CancellationToken cancellationToken);
    public Task Update(TAggregate aggregate, CancellationToken cancellationToken);
}
