using ClienteProject.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace ClienteProject.Domain.ValueObjects;

public class Cep
{
    public string Valor { get; private set; }

    protected Cep() { }
    public Cep(string valor)
    {
        if (!IsValid(valor))
            throw new EnderecoException ("O CEP informado é inválido.");
        Valor = valor;
    }

    public override string ToString() => Valor;

    public override bool Equals(object obj)
    {
        if (obj is Cep otherCep)
        {
            return Valor == otherCep.Valor;
        }
        if (obj is string cep)
        {
            return Valor == cep;
        }
        return false;
    }

    public override int GetHashCode() => Valor.GetHashCode();
    public static bool IsValid(string cep)
    {
        if (cep == null) return false;
        if (cep.Length == 8)
        {
            cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
        }
        return Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"));
    }
}

