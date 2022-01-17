namespace MessageR;

public interface IPublisher
{
    string Send<T>(T? message);
}

public class Publisher : IPublisher
{
    readonly TypeMap _map;

    public Publisher(TypeMap map)
    {
        _map = map;
    }

    public string Send<T>(T? message)
    {
        KeyValuePair<Type, Func<object?, string>> func = _map.Funcs.Single(mapFunc => mapFunc.Key == message.GetType());
        return func.Value.Invoke(message);
    }
}