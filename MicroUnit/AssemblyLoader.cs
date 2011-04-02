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
                    foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (method.Name.Length >= 4
                            && method.Name.Substring(0, 4) == "Test")
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
