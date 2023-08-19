using ClienteProject.Domain.Entities;

namespace ClienteProject.Application.UseCases.ListarDetalheCliente
{
    public class ObterDetalheClienteOutput
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string EmailPrincipal { get; set; }
        public List<string> EmailsSecundarios { get; set; }
      
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public EnderecoOutput Endereco { get; set; }

        public static ObterDetalheClienteOutput FromEntity(Cliente cliente)
        {
            var emails = new List<string>();
            if (cliente.EmailsSecundarios != null)  emails.AddRange(cliente.EmailsSecundarios.Select(x => x.ToString()).ToList());
            return new ObterDetalheClienteOutput(cliente.Id,
                          cliente.NomeCompleto,
                          cliente.EmailPrincipal.ToString(),
                          emails,
                          cliente.Telefone.ToString(),
                          cliente.Cpf.ToString(),
                          EnderecoOutput.FromEntity(cliente.Endereco));
        }
        public ObterDetalheClienteOutput(Guid id, string nome, string emailPrincipal, List<string> emailsSecundarios, string telefone, string cpf, EnderecoOutput endereco)
        {
            Id = id;
            Nome = nome;
            EmailPrincipal = emailPrincipal;
            EmailsSecundarios = emailsSecundarios;
            Telefone = telefone;
            Cpf = cpf;
            Endereco = endereco;
        }
    }
}
