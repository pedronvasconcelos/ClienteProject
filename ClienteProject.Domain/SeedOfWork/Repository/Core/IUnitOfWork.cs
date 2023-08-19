namespace ClienteProject.Domain.SeedOfWork.Repository.Core;

public interface IUnitOfWork
{
    public Task Commit(CancellationToken cancellationToken);
}
