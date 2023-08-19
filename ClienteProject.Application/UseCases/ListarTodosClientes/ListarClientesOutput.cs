using ClienteProject.Application.Core;

namespace ClienteProject.Application.UseCases.ListarTodosClientes;

public class ListarClientesOutput : PaginatedListOutput<ListarClienteModelOutput>
{
    public ListarClientesOutput(int pageNumber, 
        int pageSize,
        int totalItems,
        IReadOnlyList<ListarClienteModelOutput> items)
        : base(pageNumber, pageSize, totalItems,  items)
    {
    }

}
