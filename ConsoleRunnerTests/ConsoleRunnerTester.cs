using ConsoleRunner;
using EngineTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRunnerTests
{
    internal class TestProgram
    {
        static void Main(string[] args)
        {
            var ws1 = TestHelpers.GetWheelSet();
            var ws2 = TestHelpers.GetWheelSet();
            Runner runner = new Runner(ws1, ws2);

            runner.run();
        }
    }
}