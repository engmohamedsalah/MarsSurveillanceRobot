using System;
using System.Collections.Generic;
using System.Text;
using Application.Enums;
using Application.Model;

namespace Application.Commands
{
    public abstract class MoveCommand : Command
    {
        public static int BATTERY_CONSUMPTION = 3;

        public MoveCommand(CommandType commandType)
            : base(commandType, BATTERY_CONSUMPTION)
        { }

        protected abstract Position PotentialNextMove(Robot robot);

        public override CommandResult ProceedCommand(Robot robot)
        {
            var next = PotentialNextMove(robot);

            if (!ValidMove(robot, next) || ObstacleMove(robot, next))
                return CommandResult.Obstacle;

            robot.Position = next;
            robot.VisitedCells.Add(robot.Position.Location);

            return CommandResult.Succeeded;
        }
    }
}