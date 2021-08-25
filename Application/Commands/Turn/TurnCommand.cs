using System;
using System.Collections.Generic;
using System.Text;
using Application.Enums;
using Application.Model;

namespace Application.Commands
{
    public abstract class TurnCommand : Command
    {
        public static int BATTERY_CONSUMPTION = 2;

        public TurnCommand(CommandType commandType)
            : base(commandType, BATTERY_CONSUMPTION)
        { }

        protected abstract void Turn(Robot robot);

        public override CommandResult ProceedCommand(Robot robot)
        {
            Turn(robot);
            return CommandResult.Succeeded;
        }
    }
}