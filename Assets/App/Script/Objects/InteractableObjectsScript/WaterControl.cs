using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

public class WaterControl : MonoBehaviour
{
    [SerializeField] private WaterSink _sinkWater;
    public event Action WaterActivity;

    public void WaterCountOff()
    {
        _sinkWater.WaterOffTotal();
        WaterActivity?.Invoke();
    }

}
