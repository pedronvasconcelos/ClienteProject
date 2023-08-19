using ClienteProject.Domain.Entities;

namespace ClienteProject.Application.UseCases.ListarDetalheCliente
{
    public class EnderecoOutput
    {
        public string Logradouro { get; set; }
        public string Numero { get;  set; }
        public string? Complemento { get;  set; }
        public string Bairro { get;  set; }
        public string Cidade { get; set; }
        public string Estado { get;  set; }
        public string Cep { get;  set; }

        public static EnderecoOutput FromEntity(Endereco endereco)
        {
            return new EnderecoOutput(endereco.Logradouro,
                endereco.Numero,
                endereco.Complemento,
                endereco.Bairro,
                endereco.Cidade,
                endereco.Estado,
                endereco.Cep.ToString());
        }
        public EnderecoOutput(string logradouro, string numero, string? complemento, string bairro, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }
    }
}
