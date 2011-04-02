using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace MicroUnit
{
    public static class Console
    {
        public static Thread DispatcherThread { get; set; }
        public static bool ReportTimeStamps { get; set; }

        private static ConsoleUi _consoleUi;

        static Console()
        {
            DispatcherThread = new Thread(() =>
                                    {
                                        _consoleUi = new ConsoleUi("Test harness");
                                        new Application().Run(_consoleUi);
                                    });

            DispatcherThread.Start();
        }

        public static void WriteLine(string text)
        {
            WriteLine(text, ReportTimeStamps);
        }

        public static void WriteLine(string text, bool timeStamp)
        {
            while (_consoleUi == null) // Waiting for console window to be created by dispatcher
            {
                Thread.Sleep(10);
            }

            if (timeStamp)
            {
                text = Utility.GetMachineTime() + " " + text;
            }

            lock (_consoleUi)
            {
                _consoleUi.WriteLine(text);
            }
        }
    }
}