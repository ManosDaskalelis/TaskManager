using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Exceptions.TaskExceptions
{
    public class TaskUpdateException : Exception
    {
        public TaskUpdateException(string message, Exception? exception = null) : base(message, exception)
        {

        }
    }
}
