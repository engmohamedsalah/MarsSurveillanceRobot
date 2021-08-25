using System;
using System.Collections.Generic;
using System.Text;
using Application.Model;
using Microsoft.Extensions.Logging;

namespace Application.Service
{
    public interface IRobotService
    {
        Robot Robot { get; set; }

        void ParseFile(string inputPath, string outputPath);

        void ParseRequst(InputRequestJson inputRequestJson);
    }
}