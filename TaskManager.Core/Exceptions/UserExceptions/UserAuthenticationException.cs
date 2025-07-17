using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Exceptions.UserExceptions
{
    public class UserAuthenticationException : Exception
    {
        public UserAuthenticationException(string message, Exception? inner = null)
           : base(message, inner)
        {
        }
    }
}
