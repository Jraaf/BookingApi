using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions;

public class UserExistsException : Exception
{
    public UserExistsException(string message) : base(message)
    {
    }
    public UserExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
