using Assets.App.Script.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectDamageTrigger : MonoBehaviour
{
    [Header("Base point object")]
    [SerializeField] private ObjectPointBase _objectPoint;
    [SerializeField] private PlayerHealthController _playerHealthController;

    [Space]
    [Header("ZoneDamaged")]
    [SerializeField] private TriggerZoneController[] _electricityDamageZone;
    [SerializeField] private TriggerZoneController[] _firedDamageZone;
    [SerializeField] private TriggerZoneController[] _steamDamageZone;

    private void OnEnable()
    {
        foreach(TriggerZoneController triggerEntered in _electricityDamageZone)
        {
            triggerEntered.TriggerEntered += DamageElectricity;
        }

        foreach (TriggerZoneController triggerEntered in _firedDamageZone)
        {
            triggerEntered.TriggerEntered += DamageFire;
        }

        foreach (TriggerZoneController triggerEntered in _steamDamageZone)
        {
            triggerEntered.TriggerEntered += DamageSteam;
        }

    }

    private void OnDisable()
    {
        foreach (TriggerZoneController triggerEntered in _electricityDamageZone)
        {
            triggerEntered.TriggerEntered -= DamageElectricity;
        }

        foreach (TriggerZoneController triggerEntered in _firedDamageZone)
        {
            triggerEntered.TriggerEntered -= DamageFire;
        }

        foreach (TriggerZoneController triggerEntered in _steamDamageZone)
        {
            triggerEntered.TriggerEntered -= DamageSteam;
        }
    }

    private void DamageElectricity(Collider Collision)
    {
        if (_objectPoint.IsElectricity)
        {
            _playerHealthController.DamageElectricity();
        }
    }

    private void DamageFire(Collider Collision)
    {
        if (_objectPoint.IsFired)
        {
            _playerHealthController.DamageFire();
        }
    }

    private void DamageSteam(Collider Collision)
    {
        if (_objectPoint.IsFired)
        {
            _playerHealthController.DamageSteam();
        }
    }
}
