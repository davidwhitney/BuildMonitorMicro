using System;
using System.Collections;
using System.Reflection;

namespace MicroUnit
{
    public class AssemblyLoader
    {
        public ArrayList GatherTests()
        {
            var testMethods = new ArrayList();
            
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    // No custom attribute support in MicroFramework (they get stripped by the compiler)
                    // Use "Test_" prefix.
                    foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (method.Name.Length >= 5
                            && method.Name.Substring(0, 5) == "Test_")
                        {
                            testMethods.Add(method);
                        }
                    }
                }
            }

            return testMethods;
        }
    }
}
