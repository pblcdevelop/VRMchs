using Assets.App.Script.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTube : MonoBehaviour
{
    [SerializeField] private TriggerZoneController _triggerZoneController;
    [SerializeField] private PhoneController _phoneController;

    private void OnEnable()
    {
        _triggerZoneController.TriggerEntered += TubeInPhone;
        _triggerZoneController.TriggerExit += TubeOutPhone;
    }

    private void OnDisable()
    {
        _triggerZoneController.TriggerEntered -= TubeInPhone;
        _triggerZoneController.TriggerExit -= TubeOutPhone;
    }

    private void TubeOutPhone(Collider collision)
    {
        _phoneController.PhoneTubeOutPhone();
    }

    private void TubeInPhone(Collider collision)
    {
        _phoneController.PhoneTubeInPhone();
    }
}
