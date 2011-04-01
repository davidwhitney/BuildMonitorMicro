using System;

namespace BuildMonitorMicro.Configuration
{
    public class BuildMonitorConfiguration
    {
        public Uri BuildServerStatusPageUri { get; set; }
        public string SuccessfulBuildString { get; set; }
        public string FailedBuildString { get; set; }
    }
}
