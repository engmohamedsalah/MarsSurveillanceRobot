using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidFilePathException : Exception
    {
        private const string ToolExecutionResponseWithErrorFormatMessage = "File path is in valid \r\n{0}";

        public InvalidFilePathException(string filePath)
          : base(string.Format(ToolExecutionResponseWithErrorFormatMessage, filePath))
        {
        }
    }
}