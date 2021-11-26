using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEventManager : MonoBehaviour
{
    public delegate float FloatVar();

    static Dictionary<string, FloatVar> _fEvents = new Dictionary<string, FloatVar>();

    public static void Subscribe(string eventType, FloatVar method)
    {
        if (!_fEvents.ContainsKey(eventType))
            _fEvents.Add(eventType, method);
        else
            _fEvents[eventType] += method;
    }

    public static void UnSubscribe(string eventType, FloatVar method)
    {
        if (_fEvents.ContainsKey(eventType))
        {
            _fEvents[eventType] -= method;

            if (_fEvents[eventType] == null)
                _fEvents.Remove(eventType);
        }
    }

    public static void ResetEventDictionary()
    {
        _fEvents = new Dictionary<string, FloatVar>();
    }
}
