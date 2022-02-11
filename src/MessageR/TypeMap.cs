using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MessageR;

public class TypeMap
{
    Dictionary<Type, Func<object, string>> _funcs = new();

    public TypeMap(Assembly assembly)
    {
        foreach (var type in assembly
                     .GetTypes())
        {
            foreach (var method in type.GetMethods()
                         .Where(m => m.GetCustomAttributes().OfType<MessageHandlerAttribute>().Any()))
            {
                var instance = Activator.CreateInstance(type);

                var messageType = ((MessageHandlerAttribute)method.GetCustomAttributes().Single(x => x.GetType() == typeof(MessageHandlerAttribute))).MessageType;
                _funcs.Add(messageType, p =>  (string) method.Invoke(instance, new [] {(dynamic) p}));    
            }
            
        }
    }

    public Dictionary<Type, Func<object, string>> Funcs
    {
        get => _funcs;
        set => _funcs = value;
    }
}