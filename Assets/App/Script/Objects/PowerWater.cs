using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWater : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private ObjectPointBase _objectPointBase;
    [SerializeField] private FireHealth _fireHealth;
    [SerializeField] private int _powerWater;

    private void OnParticleCollision(GameObject objectWater)
    {
        if (objectWater.CompareTag("Water"))
        {
            CheckObjects();
        }
    }

    private void WaterDamageFire()
    {
        _fireHealth.FireMinimazeHealth(_powerWater);
    }

    private void CheckObjects()
    {
        if (_objectPointBase != null)
        {
            if (_objectPointBase.IsElectricity)
            {
                _playerHealthController.DamageElectricity();
            }
            else
            {
                WaterDamageFire();
            }
        }
    }
}
