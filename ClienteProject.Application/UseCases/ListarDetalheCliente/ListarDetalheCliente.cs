using ClienteProject.Domain.Repositories;
using ClienteProject.Domain.ValueObjects;

namespace ClienteProject.Application.UseCases.ListarDetalheCliente;
public class ObterDetalheCliente : IObterDetalheCliente
{
    private readonly IClienteRepository _clienteRepository;

    public ObterDetalheCliente(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ObterDetalheClienteOutput> Handle(ObterDetalheClienteInput request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.Get(request.Id, cancellationToken);

        return ObterDetalheClienteOutput.FromEntity(cliente);
    }
}