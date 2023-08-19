using ClienteProject.Domain.Repositories;
using ClienteProject.Domain.SeedOfWork.Repository.Core;
using FluentValidation;
namespace ClienteProject.Application.UseCases.CadastrarCliente;
public class CadastrarCliente : ICadastrarCliente
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CadastrarCliente(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
    {
        _clienteRepository = clienteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CadastrarClienteOutput> Handle(CadastrarClienteInput request, CancellationToken cancellationToken)
    {

        var validator = new CadastrarClienteInputValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException("Erro na validação do cliente", validationResult.Errors);
        }
        var cliente = request.ToEntity();
        await _clienteRepository.Insert(cliente, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);
        return CadastrarClienteOutput.FromEntity(cliente);  
    }

}
