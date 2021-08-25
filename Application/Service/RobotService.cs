using System;
using System.Collections.Generic;
using System.IO;
using Application.Commands;
using Application.Exceptions;
using Application.Helpers;
using Application.Model;
using Application.Parser;
using Microsoft.Extensions.Logging;

namespace Application.Service
{
    public class RobotService : IRobotService
    {
        public List<Command> Commands { get; set; }
        public Robot Robot { get; set; }

        private ILogger<RobotService> _logger;
        private IBackOffStrategiesService _backOffStrategiesService;
        private ICommandFactory _commandFactory;

        public RobotService(IBackOffStrategiesService backOffStrategiesService,
            ILogger<RobotService> logger,
            ICommandFactory commandFactory)
        {
            _backOffStrategiesService = backOffStrategiesService;
            _logger = logger;
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// Parses the file and simulate and save the result to output path.
        /// </summary>
        /// <param name="inputPath">The input path.</param>
        /// <param name="outputPath">The output path.</param>
        /// <exception cref="Application.Exceptions.GeneralException"></exception>
        public void ParseFile(string inputPath, string outputPath)
        {
            FileHelper.checkFilePath(inputPath);

            try
            {
                var text = File.ReadAllText(inputPath);
                InputRequestJson input = JsonParser.ParseInputFromJsonFile(text);
                ParseRequst(input);
                var output = new OutputResponseJson(Robot);
                File.WriteAllText(outputPath, JsonParser.ConvertToJson(output));
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex.Message);
            }
        }

        public void ParseRequst(InputRequestJson inputRequestJson)
        {
            Robot = new Robot(inputRequestJson, _backOffStrategiesService, _logger);

            CreateCommandSteps(inputRequestJson.Commands);

            Robot.VisitedCells.Add(Robot.Position.Location);
            //do move
            try
            {
                foreach (var c in Commands)
                {
                    c.Execute(Robot);
                }
            }

            //this exception mean there is no more move
            //so stop and return current result;
            catch (NoMoreMoveException)
            {
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creates the command steps.
        /// </summary>
        /// <param name="commands">The commands.</param>
        private void CreateCommandSteps(List<string> commands)
        {
            Commands = new List<Command>();
            foreach (var command in commands)
            {
                Commands.Add(_commandFactory.CreatCommand(command));
            }
        }
    }
}