using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Exceptions.UserExceptions
{
    public class UserRegistrationException : Exception
    {
        public UserRegistrationException(string message, Exception? exception = null) : base(message, exception)
        {
        }
    }
}
