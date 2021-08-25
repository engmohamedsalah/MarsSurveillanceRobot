using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidFileContentException : Exception
    {
        private const string ToolExecutionResponseWithErrorFormatMessage = "File is invalid Formate.\r\n File content \r\n {0}";

        public InvalidFileContentException(string errorMessage)
          : base(string.Format(ToolExecutionResponseWithErrorFormatMessage, errorMessage))
        {
        }
    }
}