namespace MicroUnit.Exceptions
{
    public class AssertPassException : ControlledAssertionException
    {
        private readonly string _message;
        public new string Message { get { return _message; } }       

        public AssertPassException(string message = null)
        {
            _message = message == null ? "Test Passed" : "Test Passed - " + message;
        }
    }
}