using MicroUnit;

namespace BuildMonitorMicro.Test.Unit
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
