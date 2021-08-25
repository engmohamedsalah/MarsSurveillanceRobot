using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class UnkownCommandException : Exception
    {
        private const string UnknownCommand = "this command {0} is unkown";

        public UnkownCommandException(string command)
         : base(string.Format(UnknownCommand, command))
        {
        }
    }
}