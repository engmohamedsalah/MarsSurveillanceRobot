using System;
using System.Collections.Generic;
using System.Text;
using Application.Model;
using Application.Enums;

namespace Application.Commands
{
    public class TakeSampleCommand : Command
    {
        public static int BATTERY_CONSUMPTION = 8;

        public TakeSampleCommand()
            : base(CommandType.TakeSample, BATTERY_CONSUMPTION)
        {
        }

        public override CommandResult ProceedCommand(Robot robot)
        {
            var x = robot.Position.Location.X;
            var y = robot.Position.Location.Y;

            var cell = robot.terrain[x, y];
            robot.SamplesCollected.Add(cell);
            return CommandResult.Succeeded;
        }
    }
}