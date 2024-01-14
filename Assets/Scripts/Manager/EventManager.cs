using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    private static Dictionary<Enum, Action> events = new Dictionary<Enum, Action>();

    public static void Subscribe(Enum eventType, Action listener)
    {
        if (events.ContainsKey(eventType))
        {
            events[eventType] += listener;
        }
        else
        {
            events[eventType] = listener;
        }
    }

    public static void Unsubscribe(Enum eventType, Action listener)
    {
        if (events.ContainsKey(eventType))
        {
            events[eventType] -= listener;
        }
    }

    public static void Execute(Enum eventType)
    {
        if (events.ContainsKey(eventType))
        {
            events[eventType]?.Invoke();
        }
    }
}

public static class EventManager<T>
{
    private static Dictionary<Enum, Action<T>> events = new Dictionary<Enum, Action<T>>();

    public static void Subscribe(Enum eventType, Action<T> listener)
    {
        if (events.ContainsKey(eventType))
        {
            events[eventType] += listener;
        }
        else
        {
            events[eventType] = listener;
        }
    }

    public static void Unsubscribe(Enum eventType, Action<T> listener)
    {
        if (events.ContainsKey(eventType))
        {
            events[eventType] -= listener;
        }
    }

    public static void Execute(Enum eventType, T eventData)
    {
        if (events.ContainsKey(eventType))
        {
            events[eventType]?.Invoke(eventData);
        }
    }
}
