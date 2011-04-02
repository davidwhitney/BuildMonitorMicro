using BuildMonitorMicro.Configuration;

namespace BuildMonitorMicro.BuildMonitoring
{
    public interface IBuildMonitor
    {
        void StartMonitoring();
        void StopMonitoring();
        void Configure(BuildMonitorConfiguration configuration);
        BuildStatus PollServer();
    }
}