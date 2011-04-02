using System;
using System.Net;
using System.Text;

namespace BuildMonitorMicro.BuildMonitoring.Http
{
    public class HttpChannel : IHttpChannel
    {
        public string RetrieveUri(Uri location)
        {
            return RetrieveUri(location, 30000);
        }

        public string RetrieveUri(Uri location, int timeout)
        {
            using (var req = WebRequest.Create(location))
            using (var response = req.GetResponse())
            using (var responseStream = response.GetResponseStream())
            {
                var buf = new byte[responseStream.Length];
                var responseLength = responseStream.Read(buf, 0, buf.Length);
                return ExtractResponseContent(buf, responseLength);
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
    }
}
