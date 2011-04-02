using System;
using System.Reflection;
using MicroUnit.Exceptions;

namespace MicroUnit
{
    public class TestRunner
    {
        public static void RunTests()
        {
            var loader = new AssemblyLoader();
            var testMethods = loader.GatherTests();

            Console.ReportTimeStamps = true;

            foreach (var untypedTest in testMethods)
            {
                var methodInfo = (MethodInfo)untypedTest;

                try
                {
                    methodInfo.Invoke(null, null);
                    Console.WriteLine(methodInfo.DeclaringType + "." + methodInfo.Name + " - Passed.");
                }
                catch(ControlledAssertionException controlledAssertionException)
                {
                    Log(methodInfo, controlledAssertionException.Message);
                }
                catch (Exception ex)
                {
                    Log(methodInfo, "Failed", ex);
                }
            }

            Console.WriteLine("End of test run.");
        }

        private static void Log(MemberInfo methodInfo, string message, Exception ex = null)
        {
            var logString = methodInfo.DeclaringType + "." + methodInfo.Name;
            if (message != null && message != string.Empty) // IsNullOrEmpty not supported in MicroFramework
            {
                logString += " - " + message + ".\r\n";
            }

            if(ex != null)
            {
                logString += " Exception-Message: " + ex.Message + " Exception-Stack: " + ex.StackTrace;
            }

            Console.WriteLine(logString);
        }
    }
}