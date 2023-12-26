using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float _currentTime;
    private bool _isTimerEnable;
    private bool _isStopTimer;

    public float CurrentTime
    {
        get => _currentTime;
        set
        {
            _currentTime = value;
        }
    }

    private void Update()
    {
        if (_isTimerEnable && !_isStopTimer)
        {
            _currentTime += 0.1f * Time.deltaTime;
        }
    }
    
    public void StartTimer()
    {
        _isTimerEnable = true;
        _isStopTimer = false;
    }

    public void StopTimer()
    {
        _isTimerEnable = false;
        _isStopTimer = true;
    }

    public void ResetTimer()
    {
        _currentTime = 0;
        _isTimerEnable = false;
        _isStopTimer = false;
    }

}
