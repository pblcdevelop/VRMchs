using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerExtinguisher : MonoBehaviour
{
    [SerializeField] private int _powerExtinguisher;
    [SerializeField] private FireHealth _firedObject;

    private void OnParticleCollision(GameObject objectExtinguisher)
    {
        if (objectExtinguisher.CompareTag("Extinguisher"))
        {
            WaterDamageFire();
        }
    }

    private void WaterDamageFire()
    {
        _firedObject.FireMinimazeHealth(_powerExtinguisher);
    }
}
