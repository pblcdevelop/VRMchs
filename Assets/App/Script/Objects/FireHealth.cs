using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealhtFire;
    public event Action<FireHealth> EndFireObject;

    public int _currentHealhtFire;
    private bool _isOnce = false;

    public int CurrentHealhtFire => _currentHealhtFire;

    private void Awake()
    {
        _currentHealhtFire = _maxHealhtFire;
    }

    private void Update()
    {
        CheckEndFire();
    }

    private void CheckEndFire()
    {
        if (_currentHealhtFire <= 0 && !_isOnce)
        {
            _isOnce = true;
            EndFire();
        }
    }

    public void MaximazeHealth(int value)
    {
        _currentHealhtFire += value;
        _isOnce = false;
    }

    public void FireMinimazeHealth(int value)
    {
        _currentHealhtFire -= value;
    }

    private void EndFire()
    {
        EndFireObject?.Invoke(this);
    }
}
