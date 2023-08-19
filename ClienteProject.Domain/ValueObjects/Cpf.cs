using ClienteProject.Domain.Exceptions;

namespace ClienteProject.Domain.ValueObjects;
public class Cpf
{
    protected Cpf() { }
    public string Numero { get; private set; }

    public Cpf(string numero)
    {
        numero = FormatarNumero(numero);

        if (!IsValid(numero))
            throw new EntityValidationException("CPF inválido");

        Numero = numero;
    }

    private static string FormatarNumero(string numero)
    {
        return numero.Trim().Replace(".", "").Replace("-", "");
    }
    public static bool IsValid(string cpf)
    {
        cpf = FormatarNumero(cpf);
        if (string.IsNullOrWhiteSpace(cpf)) return false;
        if (cpf.Length != 11) return false;

        // Verifica se o CPF não possui uma sequência de números repetidos, que são considerados inválidos.
        if (new string(cpf[0], 11) == cpf) return false;

        int peso = 10;
        int soma = 0;

        for (int i = 0; i < 9; i++)
        {
            soma += peso * int.Parse(cpf[i].ToString());
            peso--;
        }

        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        if (digito1 != int.Parse(cpf[9].ToString())) return false;

        peso = 11;
        soma = 0;
        for (int i = 0; i < 10; i++)
        {
            soma += peso * int.Parse(cpf[i].ToString());
            peso--;
        }

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return digito2 == int.Parse(cpf[10].ToString());
    }

    public override bool Equals(object obj)
    {
        if (obj is Cpf otherCpf)
        {
            return this.Numero == otherCpf.Numero;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Numero.GetHashCode();
    }

    public override string ToString()
    {
        return Numero;
    }

    public static implicit operator Cpf(string numero) => new Cpf(numero);

    public static implicit operator string(Cpf cpf) => cpf.Numero;
}