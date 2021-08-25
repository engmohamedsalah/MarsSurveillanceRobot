using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface ICommandFactory
    {
        Command CreatCommand(string command);

        List<Command> CreatCommands(string commands);
    }
}