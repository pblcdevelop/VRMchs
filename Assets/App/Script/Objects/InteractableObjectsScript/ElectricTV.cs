using Assets.App.Script.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ElectricTV : MonoBehaviour
{
    [SerializeField] private ObjectPointBase _objectTVPoint;
    [SerializeField] private ObjectFiredHallPoint _objectTVParticles;
    [SerializeField] private TriggerZoneController _electricityPower;
    [SerializeField] private XRGrabInteractable _interactbleElectricPorts;

    private void OnEnable()
    {
        _electricityPower.TriggerExit += EndElectricityTVObjects;
    }

    private void OnDisable()
    {
        _electricityPower.TriggerExit -= EndElectricityTVObjects;
    }

    private void Update()
    {
        InteractorUpdater();
    }

    private void InteractorUpdater()
    {
        if (_objectTVPoint.IsElectricity)
        {
            _interactbleElectricPorts.enabled = true;
        }
    }

    private void EndElectricityTVObjects(Collider Collisions)
    {
        _objectTVPoint.IsElectricity = false;
        _objectTVParticles.StopSpark();    
    }
}
