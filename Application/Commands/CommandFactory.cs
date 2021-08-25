using System.Collections.Generic;
using Application.Exceptions;

namespace Application.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public Command CreatCommand(string command)
        {
            switch (command.ToUpper())
            {
                case "F":
                    return new ForwardMoveCommand();

                case "B":
                    return new BackwardMoveCommand();

                case "R":
                    return new RightTurnCommand();

                case "L":
                    return new LeftTurnCommand();

                case "S":
                    return new TakeSampleCommand();

                case "E":
                    return new ExtendSolarPanelsCommand();

                default:
                    throw new UnkownCommandException(command);
            }
        }

        public List<Command> CreatCommands(string commands)
        {
            var result = new List<Command>();
            var commandList = commands.Split(',');
            for (int i = 0; i < commandList.Length; i++)
            {
                result.Add(CreatCommand(commandList[i]));
            }
            return result;
        }
    }
}