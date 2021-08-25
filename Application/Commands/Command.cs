using System;
using Application.Enums;
using Application.Exceptions;
using Application.Helpers;
using Application.Model;

namespace Application.Commands
{
    public abstract class Command
    {
        protected int BatteryConsumption { get; }

        protected CommandType CommandType { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="batteryConsumption">The battery consumption.</param>
        public Command(CommandType commandType, int batteryConsumption)
        {
            CommandType = commandType;
            BatteryConsumption = batteryConsumption;
        }

        /// <summary>
        /// Executes the specified robot.
        /// </summary>
        /// <param name="robot">The robot.</param>
        /// <returns></returns>
        /// <exception cref="Application.Exceptions.NoMoreMoveException"></exception>
        public CommandResult Execute(Robot robot)
        {
            Console.WriteLine(CommandType.ToString());
            robot.WriteLog(CommandType.ToString());
            if (robot.Battery <= 0 || robot.Battery < BatteryConsumption)
            {
                robot.WriteLog(Constants.RobotCanotMove);
                throw new NoMoreMoveException();
            }

            var result = ProceedCommand(robot);

            if (result == CommandResult.Succeeded)
                ConsumeBattery(robot);

            if (result == CommandResult.Obstacle)
                ExcuteBackOff(robot);

            return result;
        }
        /// <summary>
        /// Excutes the back off.
        /// </summary>
        /// <param name="robot">The robot.</param>
        private void ExcuteBackOff(Robot robot)
        {
            var commands = robot
                .BackOffStrategiesService
                .GetStrategyByIndex(robot.CurrentBackOfIndex);

            robot.WriteLog($"Applying Backoff #{robot.CurrentBackOfIndex + 1}");

            robot.WriteLog($"Facing {robot.Position.Facing.ToString()}");
            robot.WriteLog($"Location#{robot.Position.Location.X},{robot.Position.Location.Y}");

            robot.IncreamentCurrentBackOfIndex();

            commands.ForEach(a => a.Execute(robot));
            robot.ResetCurrentBackOfIndex();
        }

        public abstract CommandResult ProceedCommand(Robot robot);

        public bool ConsumeBattery(Robot robot)
        {
            if (robot.Battery >= BatteryConsumption)
            {
                robot.Battery -= BatteryConsumption;
                return true;
            }
            return false;
        }

        protected bool ObstacleMove(Robot robot, Position next)
        {
            return robot.terrain[next.Location.X, next.Location.Y].ToLower() == "obs";
        }

        protected bool ValidMove(Robot robot, Position next)
        {
            return next.Location.X < robot.terrain.GetLength(0)
                && next.Location.X >= 0
                && next.Location.Y >= 0
                && next.Location.Y < robot.terrain.GetLength(1)
                && robot.Battery - BatteryConsumption >= 0;
        }
    }
}