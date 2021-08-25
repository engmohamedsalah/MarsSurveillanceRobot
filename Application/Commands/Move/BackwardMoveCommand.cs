using System;
using System.Collections.Generic;
using System.Text;
using Application.Enums;
using Application.Model;

namespace Application.Commands
{
    public class BackwardMoveCommand : MoveCommand
    {
        public BackwardMoveCommand()
            : base(CommandType.Backward) { }

        /// <summary>Potentials the next move.</summary>
        /// <param name="robot">The robot.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        protected override Position PotentialNextMove(Robot robot)
        {
            var result = Position.Clone(robot.Position);

            switch (robot.Position.Facing)
            {
                case Facing.North:
                    result.Location.Y++;
                    result.Facing = Facing.South;
                    break;

                case Facing.East:
                    result.Location.X--;
                    result.Facing = Facing.West;
                    break;

                case Facing.South:
                    result.Location.Y--;
                    result.Facing = Facing.North;
                    break;

                case Facing.West:
                    result.Location.X++;
                    result.Facing = Facing.East;
                    break;

                default:
                    break;
            }
            return result;
        }
    }
}