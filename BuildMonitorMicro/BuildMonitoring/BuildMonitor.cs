using System;
using System.Net;
using System.Text;
using System.Threading;
using BuildMonitorMicro.BuildMonitoring.Http;
using BuildMonitorMicro.Configuration;

namespace BuildMonitorMicro.BuildMonitoring
{
    public delegate void BuildSucceeded();
    public delegate void BuildFailed();
    public delegate void FailedToEvaluateBuildStatus();
    
    public class BuildMonitor: IBuildMonitor
    {
        private Timer _pollingTimer;
        private BuildMonitorConfiguration _configuration;
        private readonly IHttpChannel _httpChannel;
        private readonly BuildSucceeded _buildSuccessfulCallback;
        private readonly BuildFailed _buildFailedCallback;
        private readonly FailedToEvaluateBuildStatus _failedToEvaluateBuildStatus;

        public BuildMonitor(BuildMonitorConfiguration configuration, IHttpChannel httpChannel,
                                                                     BuildSucceeded buildSuccessfulCallback, 
                                                                     BuildFailed buildFailedCallback, 
                                                                     FailedToEvaluateBuildStatus failedToEvaluateBuildStatus)
        {
            _configuration = configuration;
            _httpChannel = httpChannel;
            _buildSuccessfulCallback = buildSuccessfulCallback;
            _buildFailedCallback = buildFailedCallback;
            _failedToEvaluateBuildStatus = failedToEvaluateBuildStatus;
        }

        public void StartMonitoring()
        {
            _pollingTimer = new Timer(OnTick, null, new TimeSpan(0, 0, 0, 5), new TimeSpan(0, 0, 0, 5));
        }

        public void StopMonitoring()
        {
            _pollingTimer.Dispose();
        }

        public void Configure(BuildMonitorConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BuildStatus PollServer()
        {
            var responseContent = _httpChannel.RetrieveUri(_configuration.BuildServerStatusPageUri);
            return EvaluateBuildServerResponse(responseContent);
        }

        private void OnTick(object state)
        {
            PollServer();
        }

        private BuildStatus EvaluateBuildServerResponse(string responseContent)
        {
            var buildStatus = BuildStatus.Unknown;
            if (responseContent.IndexOf(_configuration.SuccessfulBuildString) >= 0)
            {
                buildStatus = BuildStatus.Passing;
                if (_buildSuccessfulCallback != null) _buildSuccessfulCallback();
            }
            else if (responseContent.IndexOf(_configuration.FailedBuildString) >= 0)
            {
                buildStatus = BuildStatus.Failing;
                if (_buildFailedCallback != null) _buildFailedCallback();
            }
            else
            {
                if (_failedToEvaluateBuildStatus != null) _failedToEvaluateBuildStatus();
            }

            return buildStatus;
        }
    }
}
