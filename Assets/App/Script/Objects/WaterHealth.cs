using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHealth : MonoBehaviour
{
    [SerializeField] private int _maxWaterHealth;
    public event Action<WaterHealth> EndWaterObjects;

    public int _currentWaterHealth;

    public int CurrentWaterHealth
    {
        get => _currentWaterHealth;
        set
        {
            _currentWaterHealth = value;
        }
    }

    private bool _isOnce = false;

    private void Awake()
    {
        _currentWaterHealth = _maxWaterHealth;
    }

    private void Update()
    {
        CheckEndWater();
    }

    private void CheckEndWater()
    {
        if (_currentWaterHealth <= 0 && !_isOnce)
        {
            _isOnce = true;
            EndWater();
        }
    }

    private void EndWater()
    {
        EndWaterObjects?.Invoke(this);
    }

}
