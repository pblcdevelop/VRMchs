using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScenarioManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private List<ObjectScenarioBase> _objectsScenario;
    [SerializeField] private SaveManager _saveManager;

    private int _currentPoint;

    public int Count => _objectsScenario?.Count ?? 0;

    public event Action ScenarioEndedTrue;
    public event Action ScenarioEndedNotComplete;

    private ObjectScenarioBase _currentScenarioObject;

    public int CurrentPoint
    {
        get => _currentPoint;
        set
        {
            if (value >= Count)
            {
                EndScenario();
                return;
            }
            EndActivityObgect();
            _currentPoint = value;
            StartObjectActivity();
        }
    }

    public void StartScenario(int value)
    {
        CurrentPoint = value;
    }

    private void ChangeObject()
    {
        CurrentPoint++;
    }

    private void StartObjectActivity()
    {
        _objectsScenario[_currentPoint].EndActivityObject += OnActivityEnded;
        _objectsScenario[_currentPoint].StartActivity();
        _currentScenarioObject = _objectsScenario[_currentPoint];
    }

    private void EndActivityObgect()
    {
        if (_currentScenarioObject != null)
        {
            _currentScenarioObject.EndActivityObject -= OnActivityEnded;
        }
    }

    private void OnActivityEnded()
    {
        EndActivityObgect();
        ChangeObject();
    }

    private void EndScenario()
    {
        ScenarioEndedTrue?.Invoke();
    }
}
