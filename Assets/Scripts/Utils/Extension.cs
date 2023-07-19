using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public static class Extension 
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }

    public static void AddUIEvenet(this GameObject go, Action<PointerEventData> action, UIEvent type = UIEvent.Click)
    {
        UIBase.AddEvent(go, action, type);
    }
}
