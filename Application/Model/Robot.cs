using System;
using System.Collections.Generic;
using Application.Enums;
using Application.Exceptions;
using Application.Service;
using Microsoft.Extensions.Logging;

namespace Application.Model
{
    public class Robot
    {
        public int Battery { get; set; }
        public Position Position { get; set; }

        public List<string> SamplesCollected { get; set; }

        public HashSet<Location> VisitedCells { get; set; }

        public string[,] terrain { get; set; }

        public int CurrentBackOfIndex { get; set; }

        public IBackOffStrategiesService BackOffStrategiesService { get; }

        private ILogger _logger { get; }

        public Robot(InputRequestJson json, IBackOffStrategiesService backOffStrategiesService, ILogger logger)
        {
            _logger = logger;

            Battery = json.Battery;
            Position = json.InitialPosition;

            FillMap(json);

            BackOffStrategiesService = backOffStrategiesService;

            SamplesCollected = new List<string>();
            VisitedCells = new HashSet<Location>();
        }

        public void ResetCurrentBackOfIndex()
        {
            CurrentBackOfIndex = 0;
        }

        public void IncreamentCurrentBackOfIndex()
        {
            CurrentBackOfIndex++;
            if (CurrentBackOfIndex == BackOffStrategiesService.CommandsCount())
                throw new NoMoreMoveException();
        }

        private void FillMap(InputRequestJson json)
        {
            var n = json.Terrain.Length;
            var m = json.Terrain[0].Length;

            terrain = new string[m, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    terrain[j, i] = json.Terrain[i][j];
                }
        }

        public void WriteLog(string log, LogType logType = LogType.Info)
        {
            switch (logType)
            {
                case LogType.Info:
                    _logger.LogInformation(log);
                    break;

                case LogType.Warning:
                    _logger.LogWarning(log);
                    break;

                case LogType.Error:
                    _logger.LogError(log);
                    break;

                case LogType.Trace:
                    _logger.LogTrace(log);
                    break;

                case LogType.Debug:
                    _logger.LogDebug(log);
                    break;

                case LogType.Critical:
                    _logger.LogCritical(log);
                    break;

                default:
                    break;
            }
        }
    }
}