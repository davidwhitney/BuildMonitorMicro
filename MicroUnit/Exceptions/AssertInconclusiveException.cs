namespace MicroUnit.Exceptions
{
    public class AssertInconclusiveException : ControlledAssertionException
    {
        private readonly string _message;
        public new string Message { get { return _message; } }

        public AssertInconclusiveException(string message = null)
        {
            _message = message == null ? "Test Inconclusive" : "Test Inconclusive - " + message;
        }
    }
}