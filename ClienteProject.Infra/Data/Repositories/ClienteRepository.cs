using ClienteProject.Application.Exceptions;
using ClienteProject.Domain.Repositories;
using ClienteProject.Domain.SeedOfWork.Repository.Core;
using ClienteProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClienteProject.Infra.Data.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;
    private DbSet<Cliente> _clientes
        => _context.Set<Cliente>();

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public  async Task<Cliente> Get(Guid id, CancellationToken cancellationToken)
    {
        var cliente = await _clientes
            .Include(x => x.Endereco)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && x.Active, cancellationToken);
        NotFoundException.ThrowIfNull(cliente, "Cliente não encontrado");
        return cliente!;
    }

    public async Task Insert(Cliente aggregate, CancellationToken cancellationToken)
    => await _clientes.AddAsync(aggregate, cancellationToken);

    public async Task<QueryOutput<Cliente>> Search(QueryInput input, CancellationToken cancellationToken)
    {
        var toSkip = (input.Page - 1) * input.PerPage;
        var query = _clientes.Include(x => x.Endereco).AsNoTracking().Where(x => x.Active);
        query = OrderQuery(query, input.OrderBy, input.Order);
        if (!string.IsNullOrEmpty(input.Search))
        {
            query = query.Where(x => x.NomeCompleto.Contains(input.Search) || x.Cpf.Numero.Contains(input.Search));
        }
        var total = query.Count();

        var result = await query.Skip(toSkip).
            Take(input.PerPage).
            ToListAsync();
        return new QueryOutput<Cliente>(result, input.Page, input.PerPage, total);
    }
   

    public Task Update(Cliente aggregate, CancellationToken cancellationToken)
     => Task.Run(() => _clientes.Update(aggregate), cancellationToken);
    public async Task Delete(Cliente aggregate, CancellationToken cancellationToken)
    {
        var product = await _clientes
                .FirstOrDefaultAsync(x => x.Id == aggregate.Id, cancellationToken);
        NotFoundException.ThrowIfNull(product, "Product not found");
        _clientes.Remove(product!);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    private IQueryable<Cliente> OrderQuery(IQueryable<Cliente> query, string orderProperty, QueryOrder order)
    {
        var orderedQuery = (orderProperty.ToLower(), order) switch
        {
            ("nome", QueryOrder.Asc) => query.OrderBy(x => x.NomeCompleto),
            ("nome", QueryOrder.Desc) => query.OrderByDescending(x => x.NomeCompleto),
            ("cpf", QueryOrder.Asc) => query.OrderBy(x => x.Cpf.Numero),
            ("cpf", QueryOrder.Desc) => query.OrderByDescending(x => x.Cpf.Numero),
            ("email", QueryOrder.Asc) => query.OrderBy(x => x.EmailPrincipal),
            ("email", QueryOrder.Desc) => query.OrderByDescending(x => x.EmailPrincipal),
            ("telefone", QueryOrder.Asc) => query.OrderBy(x => x.Telefone.Numero),
            ("telefone", QueryOrder.Desc) => query.OrderByDescending(x => x.Telefone.Numero),
            ("endereco", QueryOrder.Asc) => query.OrderBy(x => x.Endereco.Logradouro),
            ("endereco", QueryOrder.Desc) => query.OrderByDescending(x => x.Endereco.Logradouro),
            ("numero", QueryOrder.Asc) => query.OrderBy(x => x.Endereco.Numero),
            ("numero", QueryOrder.Desc) => query.OrderByDescending(x => x.Endereco.Numero),
            ("bairro", QueryOrder.Asc) => query.OrderBy(x => x.Endereco.Bairro),
            ("bairro", QueryOrder.Desc) => query.OrderByDescending(x => x.Endereco.Bairro),
            ("cidade", QueryOrder.Asc) => query.OrderBy(x => x.Endereco.Cidade),
            ("cidade", QueryOrder.Desc) => query.OrderByDescending(x => x.Endereco.Cidade),
            ("estado", QueryOrder.Asc) => query.OrderBy(x => x.Endereco.Estado),
            ("estado", QueryOrder.Desc) => query.OrderByDescending(x => x.Endereco.Estado),
            ("cep", QueryOrder.Asc) => query.OrderBy(x => x.Endereco.Cep),
            ("cep", QueryOrder.Desc) => query.OrderByDescending(x => x.Endereco.Cep),
            ("complemento", QueryOrder.Asc) => query.OrderBy(x => x.Endereco.Complemento),
            ("complemento", QueryOrder.Desc) => query.OrderByDescending(x => x.Endereco.Complemento),
            _ => query.OrderByDescending(x => x.NomeCompleto)
        };

        return orderedQuery;
    }
}