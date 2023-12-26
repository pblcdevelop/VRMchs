using Assets.App.Script.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject _playerVR;

    [Space]
    [Header("Trigger")]
    [SerializeField] private TriggerZoneController _triggerZoneResetPlayer;

    private void OnEnable()
    {
        _triggerZoneResetPlayer.TriggerEntered += PlayerPositionReset;
    }

    private void OnDisable()
    {
        _triggerZoneResetPlayer.TriggerEntered -= PlayerPositionReset;
    }

    private void PlayerPositionReset(Collider collision)
    {
        _playerVR.transform.position = new Vector3(0, 0.4f, 0);
    }
}
