using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Model;

namespace Application.Exceptions
{
    public class MoveFailureException : Exception
    {
        private const string ToolExecutionResponseWithErrorFormatMessage
            = "Robot cannot move forward last location {0},{1} and facing is {2}";

        public MoveFailureException(string errorMessage, Position position)
          : base(
                string.Format(ToolExecutionResponseWithErrorFormatMessage,
                                errorMessage,
                                position.Location.X,
                                position.Location.Y,
                                position.Facing))
        {
        }
    }
}