namespace BuildMonitorMicro.Hardware
{
    public interface INetworkCardDriver
    {
        void Enable(string ipAddress, string macAddress);
    }
}