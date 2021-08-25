using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Application.Enums;

namespace Application.Model
{
    public class Position
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("facing")]
        public Facing Facing { get; set; }

        public Position()
        {
            Location = new Location();
        }

        public Position(Location coordinate, Facing facing)
        {
            Location = coordinate;
            Facing = facing;
        }

        public static Position Clone(Position position)
        {
            var result = new Position();
            result.Location.X = position.Location.X;
            result.Location.Y = position.Location.Y;
            result.Facing = position.Facing;
            return result;
        }
    }
}