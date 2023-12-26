using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.App.Script.Manager;

public class FirePan : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private TriggerZoneController _triggerZonePan;
    [SerializeField] private FireHealth _fireHealth;
    [SerializeField] private int _powerPanStopFire;
    
   private void OnEnable()
    {
        _triggerZonePan.TriggerEntered += TriggerPan;
    }
    private void OnDisable()
    {
        _triggerZonePan.TriggerEntered -= TriggerPan;
    }

    private void TriggerPan(Collider collision)
    {
        _fireHealth.FireMinimazeHealth(_powerPanStopFire);
    }
}
