namespace MessageR.Test;

public class PingResponder
{
    [MessageHandler(typeof(Ping))]
    public string ReceiveAPing(Ping ping)
    {
        return $"Hello {ping.Name}";
    }
}