using MediatR;
namespace ClienteProject.Application.UseCases.CadastrarCliente;

public interface ICadastrarCliente : IRequestHandler<CadastrarClienteInput, CadastrarClienteOutput>
{

}
