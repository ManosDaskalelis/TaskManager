using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Exceptions.TaskExceptions
{
    public class TaskRetrievalException : Exception
    {
        public TaskRetrievalException(string message, Exception? exception = null) : base(message, exception)
        {

        }
    }
}
