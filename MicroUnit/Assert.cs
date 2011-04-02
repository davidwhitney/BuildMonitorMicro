using MicroUnit.Exceptions;

namespace MicroUnit
{
    public static class Assert
    {
        public static void Pass(string message = null)
        {
            throw new AssertPassException(message);
        }

        public static void Ignore(string message = null)
        {
            throw new AssertIgnoreException(message);
        }

        public static void Inconclusive(string message = null)
        {
            throw new AssertInconclusiveException(message);
        }

        public static void Fail(string message = null)
        {
            throw new AssertFailException(message);
        }

        public static void True(bool @object)
        {
            if(!@object)
            {
                throw new AssertFailException("Assert True failed.");
            }
        }

        
    }
}