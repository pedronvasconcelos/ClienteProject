using ClienteProject.Domain.Exceptions;
using System;
using System.Net;
using System.Text.RegularExpressions;
namespace ClienteProject.Domain.ValueObjects;
public abstract class Email 
{
    public string Endereco { get; private set; }

    public Email(string endereco)
    {
        Validar(endereco);
        Endereco = endereco;
    }
   
    protected Email() { }
    private static void Validar(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new EmailException("O e-mail não pode ser nulo");

        if(!IsValid(email))
                throw new EmailException("O e-mail informado não é válido"); 
    }
    public static bool IsValid(string email)
    {
        const string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
        return Regex.IsMatch(email, pattern);
        
    }

    public override string ToString() => Endereco;
    public override bool Equals(object obj)
    {
        if (obj != null && obj is Email otherEmail)
        {
            return Endereco == otherEmail.Endereco;
        }
        return false;
    }
    public static bool operator ==(Email email1, Email email2)
    {
       
        return email1.Equals(email2);
    }

    public static bool operator !=(Email email1, Email email2)
    {
        return !(email1 == email2);
    }

    public override int GetHashCode() => Endereco?.GetHashCode() ?? 0;

}
