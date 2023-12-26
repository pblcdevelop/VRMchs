using Assets.App.Script.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKnifeKitchenPoint : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private TriggerZoneController _activateObjectZone;
    [SerializeField] private ObjectsSound _soundObject;
    [SerializeField] private PlayerHealthController _playerHealthController;

    [Space]
    [Header("Objects")]
    [SerializeField] private GameObject[] _kitchenActivityObject;

    private bool _isOnce = false;
    private int _soundKnife = 0;
    

    private void OnEnable()
    {
        _activateObjectZone.TriggerEntered += StartActivity;
    }

    private void OnDisable()
    {
        _activateObjectZone.TriggerEntered -= StartActivity;
    }

    private void StartActivity(Collider collision)
    {
        if (!_isOnce)
        {
            _isOnce = true;
            _playerHealthController.DamageWarningObject();
            for (int i = 0; i < _kitchenActivityObject.Length; i++)
            {
                _kitchenActivityObject[i].GetComponent<Rigidbody>().isKinematic = false;
                _soundObject.PlaySound(_soundKnife);
            }
        }
    }
}
