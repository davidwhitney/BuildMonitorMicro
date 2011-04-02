namespace MicroUnit
{
    public static class Is
    {
        public static Assert.ThatStringContainsDeligate StringContaining(string expectedValue)
        {
            return () => (expectedValue);
        }
    }
}