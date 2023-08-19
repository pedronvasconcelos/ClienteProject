using MediatR;

namespace ClienteProject.Application.UseCases.ListarTodosClientes;

public interface IListarClientes : IRequestHandler<ListarClientesInput, ListarClientesOutput>
{ }
