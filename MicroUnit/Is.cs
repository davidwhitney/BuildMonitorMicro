namespace MicroUnit
{

    public static class Is
    {
        private static readonly IsInstance IsInstance;

        public static IsInstance Not
        {
            get { return new IsInstance(true); }
        }

        static Is()
        {
            IsInstance = new IsInstance();
        }

        public static IsInstance.StringContainsContainerDelegate StringContaining(string expectedValue)
        {
            return IsInstance.StringContaining(expectedValue);
        }
    }

    public class IsInstance
    {
        public bool Inverse { get; private set; }

        public delegate IsDelegateResponse StringContainsContainerDelegate();

        public IsInstance(bool inverse = false)
        {
            Inverse = inverse;
        }

        public StringContainsContainerDelegate StringContaining(string expectedValue)
        {
            return () => (new IsDelegateResponse(this, expectedValue));
        }

        public bool StringContaining(string outerString, string expectedValue)
        {
            var contains = false;
            if (outerString.LastIndexOf(expectedValue) > -1)
            {
                contains = true;
            }

            return !Inverse ? contains : !contains;
        }
    }
}