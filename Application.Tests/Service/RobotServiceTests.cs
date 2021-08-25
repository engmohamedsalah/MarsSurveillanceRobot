using Application.Commands;
using Application.Model;
using Application.Service;
using AutoFixture;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Application.Tests.Service
{
    [TestClass]
    public class RobotServiceTests
    {
        private IBackOffStrategiesService _backOffStrategiesService;
        private Mock<ILogger<RobotService>> _logger;
        private ICommandFactory _commandFactory;
        private IRobotService _robotService;

        [TestInitialize]
        public void TestInitialize()
        {
            _commandFactory = new CommandFactory();
            _backOffStrategiesService = new BackOffStrategiesService(_commandFactory);
            _logger = new Mock<ILogger<RobotService>>();

            _robotService = new RobotService(_backOffStrategiesService, _logger.Object, _commandFactory);
        }

        [DataRow("TestFiles/test_run_1.json", "TestFiles/test_out_1.json", "TestFiles/test_sol_1.json")]
        [DataRow("TestFiles/test_run_2.json", "TestFiles/test_out_2.json", "TestFiles/test_sol_2.json")]
        [TestMethod]
        public void ParseFile_StateUnderTest_ExpectedBehavior(string inputPath, string outputPath, string ExpectedOutputPath)
        {
            // Arrange
            JObject expectJson = JObject.Parse(File.ReadAllText(ExpectedOutputPath));

            // Act
            _robotService.ParseFile(inputPath, outputPath);

            // Assert
            JObject outJson = JObject.Parse(File.ReadAllText(outputPath));

            bool res = JToken.DeepEquals(expectJson, outJson);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void ParseRequst_StateUnderTest_ExpectedBehavior()
        {
            // Arrange

            var terrain = new string[][]
            {
                new string[] {"W", "Si", "Obs"},
                new string[] {"W", "Si", "Fe"},
                new string[] { "W", "Si", "Fe" }
            };
            var commands = new List<string>() { "F", "S", "L", "R", "S" };
            var position = new Position();
            position.Facing = Enums.Facing.South;
            position.Location.X = 0;
            position.Location.Y = 0;

            InputRequestJson inputRequestJson = new InputRequestJson(terrain, 50, commands, position);

            // Act
            _robotService.ParseRequst(inputRequestJson);

            // Assert
            Assert.AreEqual(_robotService.Robot.Battery, 27);
            Assert.AreEqual(_robotService.Robot.Position.Facing, Enums.Facing.South);
            Assert.AreEqual(_robotService.Robot.Position.Location.X, 0);
            Assert.AreEqual(_robotService.Robot.Position.Location.Y, 1);
            Assert.AreEqual(_robotService.Robot.VisitedCells.Count, 2);
        }
    }
}