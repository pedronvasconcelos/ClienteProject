using MediatR;

namespace ClienteProject.Application.UseCases.ListarDetalheCliente
{
    public interface IObterDetalheCliente : IRequestHandler<ObterDetalheClienteInput, ObterDetalheClienteOutput> { }
}
