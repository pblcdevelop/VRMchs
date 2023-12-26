using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScenarioFiredObjects : ObjectScenarioBase
{
    [Header("Base")]
    [SerializeField] private TimerController _timerObject;
    [SerializeField] private int _countActivityObject;

    [SerializeField] private List<FireHealth> _fireObjects;
    private List<FireHealth> _endedFireObject = new List<FireHealth>();
    private bool _isOnce;

    private void OnEnable()
    {
        foreach (var FiredEvent in _fireObjects)
        {
            FiredEvent.EndFireObject += Ckecked;
        }
    }
    private void OnDisable()
    {
        foreach (var FiredEvent in _fireObjects)
        {
            FiredEvent.EndFireObject -= Ckecked;
        }
    }

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

    private void Ckecked(FireHealth EndfireObjects)
    {
        if (!_endedFireObject.Contains(EndfireObjects))
        {
            _endedFireObject.Add(EndfireObjects);
            CheckFireObjects();
            Debug.Log("CheckObjectFiredList" + _endedFireObject.Count);
        }
    }

    private void CheckFireObjects()
    {
        if (_endedFireObject.Count == _countActivityObject)
        {
            EndedActivityObject();
            Debug.Log("All objects add list");
        }
    }

    private void EndedActivityObject()
    {
        base.EndActivity();
        Debug.Log("End Activity Point");
    }
}
