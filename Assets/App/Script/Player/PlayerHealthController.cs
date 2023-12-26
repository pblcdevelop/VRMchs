using Assets.App.Script.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public event Action PlayerDamage;

    private int _damageType;
    public int DamageType => _damageType;

    private int _electricityDamage = 0;
    private int _firedDamge = 1;
    private int _steamDamage = 2;
    private int _warningObjectDamage = 3;

    public void DamageElectricity()
    {
        _damageType = _electricityDamage;
        PlayerDamage?.Invoke();
    }

    public void DamageFire()
    {
        _damageType = _firedDamge;
        PlayerDamage?.Invoke();
    }

    public void DamageSteam()
    {
        _damageType = _steamDamage;
        PlayerDamage?.Invoke();
    }

    public void DamageWarningObject()
    {
        _damageType = _warningObjectDamage;
        PlayerDamage.Invoke();
    }
}
