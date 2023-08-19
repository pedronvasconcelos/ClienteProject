using ClienteProject.Domain.Repositories;
using ClienteProject.Domain.SeedOfWork.Repository.Core;

namespace ClienteProject.Application.UseCases.ListarTodosClientes;
public class ListarClientes : IListarClientes
{
    private readonly IClienteRepository _clienteRepository;

    public ListarClientes(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ListarClientesOutput> Handle(ListarClientesInput request, CancellationToken cancellationToken)
    {
        var queryOutput = await _clienteRepository.Search(
            new QueryInput(
                request.Page, 
                request.PerPage,
                request.Search,
                request.Sort,
                request.Dir), cancellationToken);
       
        return new ListarClientesOutput(queryOutput.CurrentPage,
            queryOutput.PerPage,
            queryOutput.Total,
            queryOutput.Items.Select(ListarClienteModelOutput.FromEntity).ToList());
    }
}
