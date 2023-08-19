using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteProject.Domain.Exceptions;
public class EnderecoException : EntityValidationException
{
    public EnderecoException(string message) : base(message) { }
}
