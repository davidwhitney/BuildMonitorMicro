using System;
using System.Reflection;

namespace MicroUnit
{
    public class TestRunner
    {
        public void RunTests()
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
                catch (Exception ex)
                {
                    Console.WriteLine(methodInfo.DeclaringType + "." + methodInfo.Name + "Failed. " + ex.Message + " " + ex.StackTrace);
                }
            }

            Console.WriteLine("End of test run.");
        }
    }
}