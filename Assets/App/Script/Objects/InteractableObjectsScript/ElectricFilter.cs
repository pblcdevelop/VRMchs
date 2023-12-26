using Assets.App.Script.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ElectricFilter : MonoBehaviour
{
    [SerializeField] private ObjectPointBase _objectPoint;
    [SerializeField] private ObjectFiredHallPoint[] _objectFiredParticles;
    [SerializeField] private TriggerZoneController _electricityPower;
    [SerializeField] private XRGrabInteractable _interactbleElectricPorts; 

    private void OnEnable()
    {
        _electricityPower.TriggerExit += EndElectricityFilterObjects;
    }

    private void OnDisable()
    {
        _electricityPower.TriggerExit -= EndElectricityFilterObjects;
    }

    private void Update()
    {
        InteractorUpdater();
    }

    private void InteractorUpdater()
    {
        if (_objectPoint.IsElectricity)
        {
            _interactbleElectricPorts.enabled = true;
        }
    }

    private void EndElectricityFilterObjects(Collider Collisions)
    {
        for (int i = 0; i < _objectFiredParticles.Length; i++)
        {
            _objectFiredParticles[i].StopSpark();
        }
    }
}
