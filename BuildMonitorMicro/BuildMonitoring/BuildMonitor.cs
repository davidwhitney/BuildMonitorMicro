using System;
using System.Net;
using System.Text;
using System.Threading;
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
        private readonly BuildSucceeded _buildSuccessfulCallback;
        private readonly BuildFailed _buildFailedCallback;
        private readonly FailedToEvaluateBuildStatus _failedToEvaluateBuildStatus;

        public BuildMonitor(BuildMonitorConfiguration configuration, BuildSucceeded buildSuccessfulCallback, 
                                                                     BuildFailed buildFailedCallback, 
                                                                     FailedToEvaluateBuildStatus failedToEvaluateBuildStatus)
        {
            _configuration = configuration;
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

        private void OnTick(object state)
        {
            using (var req = WebRequest.Create(_configuration.BuildServerStatusPageUri))
            using (var response = req.GetResponse())
            using (var responseStream = response.GetResponseStream())
            {
                var buf = new byte[responseStream.Length];
                var responseLength = responseStream.Read(buf, 0, buf.Length);
                var responseContent = ExtractResponseContent(buf, responseLength);
                EvaluateBuildServerResponse(responseContent);
            }
        }

        private static string ExtractResponseContent(byte[] buf, int responseLength)
        {
            var index = 0;
            var responsechars = new char[responseLength];
            foreach (var c in Encoding.UTF8.GetChars(buf))
            {
                responsechars[index] = c;
                index++;
            }

            return new String(responsechars);
        }

        private void EvaluateBuildServerResponse(string responseContent)
        {
            if (responseContent.IndexOf(_configuration.SuccessfulBuildString) >= 0)
            {
                if (_buildSuccessfulCallback != null) _buildSuccessfulCallback();
            }
            else if (responseContent.IndexOf(_configuration.FailedBuildString) >= 0)
            {
                if (_buildFailedCallback != null) _buildFailedCallback();
            }
            else
            {
                if (_failedToEvaluateBuildStatus != null) _failedToEvaluateBuildStatus();
            }
        }
    }
}
