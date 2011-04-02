using System;
using BuildMonitorMicro.BuildMonitoring;
using Microsoft.SPOT;

namespace BuildMonitorMicro.Test.Unit
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
