namespace ClienteProject.Domain.ValueObjects;

public class EmailPrincipal : Email
{
    public EmailPrincipal(string endereco) : base(endereco)
    {
    }
    public EmailPrincipal() { }
    public static implicit operator string(EmailPrincipal email) => email.ToString();
    public static explicit operator EmailPrincipal(string emailStr) => new EmailPrincipal(emailStr);

}
