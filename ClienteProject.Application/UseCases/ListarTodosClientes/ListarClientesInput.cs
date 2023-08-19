using ClienteProject.Application.Core;
using ClienteProject.Domain.SeedOfWork.Repository.Core;
using MediatR;

namespace ClienteProject.Application.UseCases.ListarTodosClientes;

public class ListarClientesInput : PaginatedListInput, IRequest<ListarClientesOutput>
{
    public ListarClientesInput(int pageNumber = 1 , int pageSize = 15,
        string search = "",
        string sort = "",
        QueryOrder dir = QueryOrder.Asc) :
        base(pageNumber, pageSize, search, sort, dir)
    {
    }
    public ListarClientesInput() :
    base(1, 15, "", "", QueryOrder.Asc)
    {
    }
}
