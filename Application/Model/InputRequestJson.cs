using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Model
{
    public class InputRequestJson
    {
        [JsonPropertyName("terrain")]
        public string[][] Terrain { get; set; }

        [JsonPropertyName("Battery")]
        public int Battery { get; set; }

        [JsonPropertyName("commands")]
        public List<string> Commands { get; set; }

        [JsonPropertyName("initialPosition")]
        public Position InitialPosition { get; set; }

        public InputRequestJson(string[][] terrain,
                                    int battery,
                                    List<string> commands,
                                    Position initialPosition)
        {
            Terrain = terrain;
            Battery = battery;
            Commands = commands;
            InitialPosition = initialPosition;
        }
    }
}