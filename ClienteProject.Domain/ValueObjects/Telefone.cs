using ClienteProject.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClienteProject.Domain.ValueObjects;
public class Telefone
{
    public string Numero { get; private set; }

     Telefone() { }
    public Telefone(string numero)
    {
        numero = LimparNumero(numero);
        Validar(numero);
        Numero = numero;
    }

    private static void Validar(string telefone)
    {
        if (string.IsNullOrWhiteSpace(telefone))
            throw new TelefoneException("O número de telefone não pode ser nulo");

        var result = IsValid(telefone);
        if (!result)
            throw new TelefoneException("O número de telefone informado não é válido");
    }


    public static string LimparNumero(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
            return string.Empty;

        
        return new string(numero.Where(char.IsDigit).ToArray());
    }   
    public static bool IsValid(string telefone)
    {
        telefone = LimparNumero(telefone);

        return  telefone.Length ==10 || telefone.Length == 11;
        
    }

    public override string ToString() => Numero;

    public override bool Equals(object obj)
    {
        if (obj != null && obj is Telefone otherTelefone)
        {
            return Numero == otherTelefone.Numero;
        }
        return false;
    }

    public static bool operator ==(Telefone telefone1, Telefone telefone2)
    {
        if (ReferenceEquals(telefone1, null) && ReferenceEquals(telefone2, null))
            return true;
        if (ReferenceEquals(telefone1, null) || ReferenceEquals(telefone2, null))
            return false;

        return telefone1.Equals(telefone2);
    }

    public static bool operator !=(Telefone telefone1, Telefone telefone2)
    {
        return !(telefone1 == telefone2);
    }

    public override int GetHashCode() => Numero?.GetHashCode() ?? 0;
}


