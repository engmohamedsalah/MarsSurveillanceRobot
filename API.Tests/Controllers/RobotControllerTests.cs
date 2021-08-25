using API.Controllers;
using Application.Commands;
using Application.Enums;
using Application.Model;
using Application.Service;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace API.Tests.Controllers
{
    [TestClass]
    public class RobotControllerTests
    {
        private IBackOffStrategiesService _backOffStrategiesService;
        private Mock<ILogger<RobotController>> _logger;
        private Mock<ILogger<RobotService>> _loggerService;
        private ICommandFactory _commandFactory;
        private IRobotService _robotService;

        [TestInitialize]
        public void TestInitialize()
        {
            _commandFactory = new CommandFactory();
            _backOffStrategiesService = new BackOffStrategiesService(_commandFactory);
            _logger = new Mock<ILogger<RobotController>>();
            _loggerService = new Mock<ILogger<RobotService>>();

            _robotService = new RobotService(_backOffStrategiesService, _loggerService.Object, _commandFactory);
        }

        [TestMethod]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var robotController = new RobotController(_robotService, _logger.Object);

            // Act
            var result = robotController.Index();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var robotController = new RobotController(_robotService, _logger.Object);
            var terrain = new string[][]
          {
                new string[] {"W", "Si", "Obs"},
                new string[] {"W", "Si", "Fe"},
                new string[] { "W", "Si", "Fe" }
          };
            var commands = new List<string>() { "F", "S", "L", "R", "S" };
            var position = new Position();
            position.Facing = Facing.South;
            position.Location.X = 0;
            position.Location.Y = 0;

            InputRequestJson inputRequestJson = new InputRequestJson(terrain, 50, commands, position);

            // Act
            var result = robotController.Create(inputRequestJson);

            // Assert
            Assert.AreEqual(result.Robot.Battery, 27);
            Assert.AreEqual(_robotService.Robot.Position.Facing, Facing.South);
            Assert.AreEqual(_robotService.Robot.Position.Location.X, 0);
            Assert.AreEqual(_robotService.Robot.Position.Location.Y, 1);
            Assert.AreEqual(_robotService.Robot.VisitedCells.Count, 2);
        }
    }
}