using Google.Protobuf;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class ProtoExtension
{
    public static T Deserialize<T>(this byte[] value) where T : class, IMessage<T>
    {
        var typeOfT = typeof(T);
        var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeOfT.Name);
        var parser = type?.GetProperty("Parser", BindingFlags.Public | BindingFlags.Static)?.GetValue(null, null) as MessageParser<T>;

        if (parser == null)
        {
            Debug.Log("While deserializing of type " + typeof(T).Name + " an error occured!");
            return null;
        }

        return parser.ParseFrom(value);
    }

}
