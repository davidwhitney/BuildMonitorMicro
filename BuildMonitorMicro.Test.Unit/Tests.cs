using BuildMonitorMicro.BuildMonitoring;

namespace BuildMonitorMicro.TestHarness
{
    public class Tests
    {
        public void Test_SomeTest()
        {
            var buildMonitor = new BuildMonitor(null, null, null, null, null);
            buildMonitor.PollServer();
        }
    }
}
