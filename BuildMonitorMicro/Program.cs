using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using BuildMonitorMicro.BuildMonitoring;
using BuildMonitorMicro.BuildMonitoring.Http;
using BuildMonitorMicro.Configuration;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace BuildMonitorMicro
{
    public class Program
    {
        private static BuildMonitor _monitor;

        public static void Main()
        {
            var httpChannel = new HttpChannel();
            var configuration = new BuildMonitorConfiguration
                                    {
                                        BuildServerStatusPageUri = new Uri("http://www.google.com"),
                                        SuccessfulBuildString = "I r successful",
                                        FailedBuildString = "I r failed"
                                    };

            _monitor = new BuildMonitor(configuration, httpChannel, OnSuccessfulBuild, OnFailedBuild, OnErrorDeterminingBuildStatus);
            _monitor.StartMonitoring();

            while(true)
            {
                Thread.Sleep(500);
            }
        }

        public static void OnSuccessfulBuild()
        {
        }

        private static void OnFailedBuild()
        {
        }

        private static void OnErrorDeterminingBuildStatus()
        {
        }
    }
}
