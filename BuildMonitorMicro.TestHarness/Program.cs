using System;
using System.Reflection;
using MicroUnit;

namespace BuildMonitorMicro.TestHarness
{
    public class Program : Microsoft.SPOT.Application
    {
        public static void Main(string [] eventArgs)
        {
            var runner = new TestRunner();
            runner.RunTests();
        }
    }
}
