using Application.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Application.Tests.Commands
{
    [TestClass]
    public class CommandFactoryTests
    {
        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private CommandFactory CreateFactory()
        {
            return new CommandFactory();
        }

        [DataRow("F", nameof(ForwardMoveCommand))]
        [DataRow("B", nameof(BackwardMoveCommand))]
        [DataRow("L", nameof(LeftTurnCommand))]
        [DataRow("R", nameof(RightTurnCommand))]
        [TestMethod]
        public void CreatCommand_StateUnderTest_ExpectedBehavior(string command, string expectedCommand)
        {
            // Arrange
            var factory = this.CreateFactory();

            // Act
            var result = factory.CreatCommand(command);

            // Assert
            Assert.AreEqual(result.GetType().Name, expectedCommand);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void CreatCommands_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();
            string commands = null;

            // Act
            var result = factory.CreatCommands(
                commands);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}