using ClienteProject.Domain.SeedOfWork.Repository.Core;
using ClienteProject.Domain.Entities;

namespace ClienteProject.Domain.Repositories;
public interface IClienteRepository : IRepository<Cliente>, IQueryableRepository<Cliente>
{
}