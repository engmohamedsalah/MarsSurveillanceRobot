using System;
using System.Collections.Generic;
using System.Text;
using Application.Enums;
using Application.Model;

namespace Application.Commands
{
    public class ForwardMoveCommand : MoveCommand
    {
        public ForwardMoveCommand()
            : base(CommandType.Forward)
        { }

        protected override Position PotentialNextMove(Robot robot)
        {
            var result = Position.Clone(robot.Position);

            switch (robot.Position.Facing)
            {
                case Facing.North:
                    result.Location.Y--;
                    break;

                case Facing.East:
                    result.Location.X++;
                    break;

                case Facing.South:
                    result.Location.Y++;
                    break;

                case Facing.West:
                    result.Location.X--;
                    break;

                default:
                    break;
            }
            return result;
        }
    }
}