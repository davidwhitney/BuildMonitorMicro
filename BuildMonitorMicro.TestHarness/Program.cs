using System.Threading;
using Microsoft.SPOT.Input;

namespace BuildMonitorMicro.TestHarness
{
    public class Program : Microsoft.SPOT.Application
    {
        public static void Main()
        {
            Console.ReportTimeStamps = true;
            Console.UseRelativeTime = true;

            for (int i = 1; i <= 25; i++)
            {
                Console.WriteLine("Hi from console line " + i);

                Thread.Sleep(i * 10);
            }
        }

        
    }
}
