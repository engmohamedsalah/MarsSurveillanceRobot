using System;
using System.Collections.Generic;
using System.Text;
using Application.Enums;
using Application.Model;

namespace Application.Commands
{
    public class RightTurnCommand : TurnCommand
    {
        public RightTurnCommand()
            : base(CommandType.TurnRight)
        { }

        protected override void Turn(Robot robot)
        {
            switch (robot.Position.Facing)
            {
                case Facing.North:
                    robot.Position.Facing = Facing.East;
                    break;

                case Facing.East:
                    robot.Position.Facing = Facing.South;
                    break;

                case Facing.South:
                    robot.Position.Facing = Facing.West;
                    break;

                case Facing.West:
                    robot.Position.Facing = Facing.North;
                    break;

                default:
                    break;
            }
        }
    }
}