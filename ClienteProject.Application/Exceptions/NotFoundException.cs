using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteProject.Application.Exceptions;
public class NotFoundException : ApplicationException
{
    public NotFoundException(string? message) : base(message)
    { }

    public static void ThrowIfNull(
        object? _object,
        string exceptionMessage)
    {
        if (_object == null)
            throw new NotFoundException(exceptionMessage);
    }
}
