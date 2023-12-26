using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.App.Script.Manager;

public class FabricFixTube : MonoBehaviour
{
    [SerializeField] private TriggerZoneController _waterTubeZone;
    [SerializeField] private WaterHealth _waterHealth;
    private void OnEnable()
    {
        _waterTubeZone.TriggerEntered += TubeFixed;
    }
    private void OnDisable()
    {
        _waterTubeZone.TriggerEntered -= TubeFixed;
    }

    private void TubeFixed(Collider collision)
    {
        _waterHealth.CurrentWaterHealth = 0;
    }
}
