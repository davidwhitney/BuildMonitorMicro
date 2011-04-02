using System;

namespace BuildMonitorMicro.BuildMonitoring.Http
{
    public interface IHttpChannel
    {
        string RetrieveUri(Uri location);
        string RetrieveUri(Uri location, int timeout);
    }
}