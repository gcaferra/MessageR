namespace MessageR;

public interface IMessageBus
{
    void Subscribe(string topic, Func<object> func);
}

public class MessageBus : IMessageBus
{
    internal Dictionary<string, Func<object>> _busSubscription = new();
    public void Subscribe(string topic, Func<object> func)
    {
        _busSubscription.Add(topic, func);
    }
    
}