using System;
using BuildMonitorMicro.BuildMonitoring;
using MicroUnit;

namespace BuildMonitorMicro.Test.Unit.BuildMonitoring
{
    public class BuildMonitorTests
    {
        public void Test_SomeTest()
        {
            var exceptionThrown = Assert.Throws(typeof(Exception), () => { new BuildMonitor(null, null, null, null, null); });


            //var buildMonitor = new BuildMonitor(null, null, null, null, null);
            //buildMonitor.PollServer();

        }
    }
}
