using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScenarioWaterObjects : ObjectScenarioBase
{
    [Header("Base")]
    [SerializeField] private TimerController _timerObject;
    [SerializeField] private WaterHealth _waterHealthObject;

    private void OnEnable()
    {
        _waterHealthObject.EndWaterObjects += EndedActivityObject;
    }
    private void OnDisable()
    {
        _waterHealthObject.EndWaterObjects += EndedActivityObject;
    }


    private bool _isOnce = false;

    // BaseActivity
    public override void StartActivity()
    {
        base.StartActivity();
    }

    public override void EndActivity()
    {
        base.EndActivity();
    }

    private void Update()
    {
        ActivityObjects();
    }

    private void ActivityObjects()
    {
        if (base._isObjectActivity)
        {
            if (!_isOnce)
            {
                _timerObject.StartTimer();
                _isOnce = true;
            }
        }
    }

    private void EndedActivityObject(WaterHealth EndWaterObjects)
    {
        base.EndActivity();
    }
}
