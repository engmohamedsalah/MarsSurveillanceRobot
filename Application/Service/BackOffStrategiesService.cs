using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.Exceptions;

namespace Application.Service
{
    public class BackOffStrategiesService : IBackOffStrategiesService
    {
        private ICommandFactory _commandFactory;

        public const string Strategies = @"E,R,F;
                                         E,L,F;
                                         E,L,L,F;
                                         E,B,R,F;
                                         E,B,B,L,F;
                                         E,F,F;
                                         E,F,L,F,L,F";

        private List<List<Command>> BackOffStrategyCommands { get; set; }

        public BackOffStrategiesService(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
            CreatDefaultBackOffStrategiesCommands();
        }

        public List<Command> GetStrategyByIndex(int index)
        {
            if (BackOffStrategyCommands == null)
                throw new NoBackOffStrategyException();
            if (index >= BackOffStrategyCommands.Count)
                throw new NoMoreMoveException();
            return BackOffStrategyCommands[index];
        }

        private void CreatDefaultBackOffStrategiesCommands()
        {
            BackOffStrategyCommands = new List<List<Command>>();

            foreach (var Strategy in Strategies.Split(';').Select(a => a.Trim()))
            {
                BackOffStrategyCommands.Add(_commandFactory.CreatCommands(Strategy));
            }
        }

        public int CommandsCount()
        {
            return BackOffStrategyCommands.Count();
        }
    }
}