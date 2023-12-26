using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectZoneDamage : MonoBehaviour
{
    public event Action PlayerZoneDamage;
    private float _timeToActivateZoneDamage;

    public void DamagePlayerToZone()
    {
        StartCoroutine(WaitTimeToActions());
    }

    private IEnumerator WaitTimeToActions()
    {
        yield return new WaitForSeconds(_timeToActivateZoneDamage);
        PlayerZoneDamage?.Invoke(); 
    }
}
