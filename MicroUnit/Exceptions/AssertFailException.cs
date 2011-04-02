using System;

namespace MicroUnit.Exceptions
{
    public class AssertFailException : Exception
    {
        private readonly string _message;
        public new string Message { get { return _message; } }

        public AssertFailException(string message = null)
        {
            _message = message == null ? "Test Failed" : "Test Failed - " + message;
        }
    }
}