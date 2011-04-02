namespace MicroUnit
{
    public class IsDelegateResponse
    {
        public IsInstance Is { get; set; }
        public string Value { get; set; }

        public IsDelegateResponse(IsInstance @is, string value)
        {
            Is = @is;
            Value = value;
        }
    }
}