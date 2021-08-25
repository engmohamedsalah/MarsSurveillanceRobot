using System;
using System.IO;
using Application.Model;
using Application.Parser;
using Application.Service;

using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

namespace obs_test

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //var filePath = "C:\\Users\\Mohamed Salah\\Downloads\\Backend Test 2 (1)\\test_run_1.json";
            //// InputRequestJson r = JsonParser.ParseInputFromJsonFile(filePath);
            //// Console.WriteLine(r.Battery);
            //string text = File.ReadAllText(filePath);

            //var serv = new RobotService(text, new BackOffStrategiesService());
            //Console.WriteLine(serv.Robot.Battery);

            if (args.Length == 0)
                //Process.Start("C:\\Users\\Mohamed Salah\\source\\repos\\MarsSurveillanceRobot\\API\\bin\\Debug\\netcoreapp3.1\\API.exe");
                Process.Start("API.exe");
        }
    }
}