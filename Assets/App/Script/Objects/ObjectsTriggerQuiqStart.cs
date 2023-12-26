using Assets.App.Script.Manager;
using UnityEngine;

public class ObjectsTriggerQuiqStart : MonoBehaviour
{
    [SerializeField] private ObjectScenarioBase _objectsScenarioBase;
    [SerializeField] private TriggerZoneController _quiqStartZone;
    [SerializeField] private TimerController _timerObject;
    [SerializeField] private float _timeToQuickStart;

    private void OnEnable()
    {
        _quiqStartZone.TriggerEntered += QuickStartActivityObject;
    }

    private void OnDisable()
    {
        _quiqStartZone.TriggerEntered -= QuickStartActivityObject;
    }

    private void QuickStartActivityObject(Collider collision)
    {
        if (_objectsScenarioBase._isObjectActivity)
        {
            if (_timerObject.CurrentTime <= _timeToQuickStart)
            {
                _timerObject.CurrentTime = _timeToQuickStart;
                _quiqStartZone.enabled = false;
            }
        }
    }
}
