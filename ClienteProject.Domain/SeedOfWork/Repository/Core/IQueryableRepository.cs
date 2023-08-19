namespace ClienteProject.Domain.SeedOfWork.Repository.Core;

public interface IQueryableRepository<TAggregate> where TAggregate : AggregateRoot
{
    Task<QueryOutput<TAggregate>> Search(
        QueryInput input,
        CancellationToken cancellationToken
    );

}
