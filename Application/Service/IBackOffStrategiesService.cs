using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;

namespace Application.Service
{
    public interface IBackOffStrategiesService
    {
        List<Command> GetStrategyByIndex(int index);

        int CommandsCount();
    }
}