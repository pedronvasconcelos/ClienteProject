
namespace ClienteProject.Domain.Exceptions;
public class EmailException : EntityValidationException
{


    public EmailException(string message)
        : base(message)
    { }
}
