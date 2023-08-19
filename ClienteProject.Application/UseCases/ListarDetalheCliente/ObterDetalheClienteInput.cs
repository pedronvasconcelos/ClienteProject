using MediatR;

namespace ClienteProject.Application.UseCases.ListarDetalheCliente
{
    public class ObterDetalheClienteInput : IRequest<ObterDetalheClienteOutput>
    {
        public Guid Id { get; set; }

        public ObterDetalheClienteInput(Guid id)
            => Id = id;
    }
}
