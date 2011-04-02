using BuildMonitorMicro.BuildMonitoring;
using MicroUnit;

namespace BuildMonitorMicro.Test.Unit.BuildMonitoring
{
    public class BuildMonitorTests
    {
        public void Test_SomeTest()
        {
            Assert.Pass();
            var buildMonitor = new BuildMonitor(null, null, null, null, null);
            buildMonitor.PollServer();

        }
    }
}
