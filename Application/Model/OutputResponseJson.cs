using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Application.Enums;
using Newtonsoft.Json;

namespace Application.Model
{
    public class OutputResponseJson
    {
        [JsonPropertyName("VisitedCells")]
        public List<Location> VisitedCells { get; set; }

        [JsonPropertyName("SamplesCollected")]
        public List<string> SamplesCollected { get; set; }

        [JsonPropertyName("Battery")]
        public int Battery { get; set; }

        [JsonPropertyName("FinalPosition")]
        public Position FinalPosition { get; set; }

        public OutputResponseJson(List<Location> visitedCells,
                                  List<string> samplesCollected,
                                  int battery,
                                  Position finalPosition)
        {
            VisitedCells = visitedCells;
            SamplesCollected = samplesCollected;
            Battery = battery;
            FinalPosition = finalPosition;
        }

        public OutputResponseJson(Robot robot)
        {
            VisitedCells = robot.VisitedCells.ToList();
            SamplesCollected = robot.SamplesCollected;
            Battery = robot.Battery;
            FinalPosition = robot.Position;
        }
    }
}