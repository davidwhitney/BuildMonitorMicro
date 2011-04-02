namespace MicroUnit.Exceptions
{
    public class AssertIgnoreException : ControlledAssertionException
    {
        private readonly string _message;
        public new string Message { get { return _message; } }

        public AssertIgnoreException(string message = null)
        {
            _message = message == null ? "Test Ignored" : "Test Ignored - " + message;
        }
    }
}