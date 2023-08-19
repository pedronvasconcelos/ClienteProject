using ClienteProject.Domain.SeedOfWork.Repository.Core;

namespace ClienteProject.Infra.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public Task Commit(CancellationToken cancellationToken)
            => _context.SaveChangesAsync(cancellationToken);

}
