using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPointBase : MonoBehaviour
{
    protected bool _isElectricity;
    public bool IsElectricity
    {
        get => _isElectricity;
        set
        {
            _isElectricity = value;
        }
    }

    protected bool _isFired;
    public bool IsFired
    {
        get => _isFired;
        set
        {
            _isFired = value;
        }
    }

    protected bool _isWater;
    public bool IsWater
    {
        get => _isWater;
        set
        {
            _isWater = value;
        }
    }

    protected bool _isSteam;
    public bool IsSteam
    {
        get => _isSteam;
        set
        {
            _isSteam = value;
        }
    }

    protected bool _isWartning;
    public bool IsWarning
    {
        get => _isWartning;
        set
        {
            _isWartning = value;
        }
    }
}
