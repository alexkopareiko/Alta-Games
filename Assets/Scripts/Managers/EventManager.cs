using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<float> Tick01;
    public static event Action<float> Tick1;

    // 0.1 second
    public static void StartTick01()
    {
        Tick01?.Invoke(0.1f);
    }

    // 1 second
    public static void StartTick1()
    {
        Tick1?.Invoke(1f);
    }

}
