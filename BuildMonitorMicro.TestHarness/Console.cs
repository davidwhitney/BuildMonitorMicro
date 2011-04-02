using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace BuildMonitorMicro.TestHarness
{
    public static class Console
    {
        public static Thread DispatcherThread { get; set; }
        public static bool ReportTimeStamps { get; set; }
        public static bool UseRelativeTime { get; set; }

        private static ConsoleWindow _consoleWindow;

        static Console()
        {
            DispatcherThread = new Thread(() =>
                                    {
                                        _consoleWindow = new ConsoleWindow("Test harness");
                                        new Application().Run(_consoleWindow);
                                    });

            DispatcherThread.Start();
        }

        public static void WriteLine(string text)
        {
            WriteLine(text, ReportTimeStamps);
        }

        public static void WriteLine(string text, bool timeStamp)
        {
            while (_consoleWindow == null) // Waiting for console window to be created by dispatcher
            {
                Thread.Sleep(10);
            }

            if (timeStamp)
            {
                text = Utility.GetMachineTime() + " " + text;
            }

            lock (_consoleWindow)
            {
                _consoleWindow.WriteLine(text);
            }
        }
    }
}