using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectScenarioBase : MonoBehaviour
{
    public event Action StartActivityObject;
    public event Action EndActivityObject;

    public bool _isObjectActivity;
    public bool _isObjectEndActivity;

    public virtual void StartActivity()
    {
        _isObjectActivity = true;
        StartActivityObject?.Invoke();
    }

    public virtual void EndActivity()
    {
        _isObjectActivity = false;
        _isObjectEndActivity = true;
        EndActivityObject?.Invoke();
    }
}
