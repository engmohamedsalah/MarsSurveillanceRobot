using System;
using System.Collections.Generic;
using System.Text;
using Application.Enums;
using Application.Model;

namespace Application.Commands
{
    public class ExtendSolarPanelsCommand : Command
    {
        public static int BATTERY_CONSUMPTION = 1;
        public static int BATTERY_RECHARGE = 10;

        public ExtendSolarPanelsCommand()
            : base(CommandType.ExtendSolarPanels, BATTERY_CONSUMPTION)
        {
        }

        public override CommandResult ProceedCommand(Robot robot)
        {
            robot.Battery += BATTERY_RECHARGE;
            return CommandResult.Succeeded;
        }
    }
}