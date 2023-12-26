using Assets.App.Script.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPointWaterTube : ObjectPointBase
{
    [Header("Base")]
    [SerializeField] private TimerController _timerController;
    [SerializeField] private WaterHealth _waterHealth;
    [SerializeField] private PhoneController _phoneVictorine;

    [Space]
    [Header("InteractObjects")]
    [SerializeField] private GameObject _tubeNormal;
    [SerializeField] private GameObject _tubeDamage;
    [SerializeField] private GameObject _fabricObjectTube;
    [SerializeField] private GameObject[] _intertactFabricObject;

    [Space]
    [Header("Particles")]
    [SerializeField] private ObjectsParticles _particlesTube;
    [SerializeField] private ObjectsSound _soundTube;

    [Space]
    [Header("Parametrs")]
    [SerializeField] private int[] _timeToActions;

    private bool _isOnce = false;
    private bool _isOnceActive = false;

    private int _startWaterStream = 0;
    private int _startSteam = 1;
    private int _startWaterLeaking = 2;

    private int _soundDamageTube = 0;
    private int _soundWaterStream = 1;
    private int _soundSteam = 2;
    private int _soundWaterLeaking = 3;

    private void OnEnable()
    {
        _waterHealth.EndWaterObjects += LicvidateDamageTube;
    }
    private void OnDisable()
    {
        _waterHealth.EndWaterObjects -= LicvidateDamageTube;
    }


    private void Update()
    {
        ParticlesActivateTube();
    }

    private void ParticlesActivateTube() 
    { 
        if(!_isOnce && _timerController.CurrentTime >= _timeToActions[0])
        {
            base.IsWater = true;
            base.IsSteam = true;
            _isOnce = true;
            _particlesTube.StartParticles(_startWaterStream);
            _particlesTube.StartParticles(_startSteam);

            _soundTube.PlaySound(_soundDamageTube);
            _soundTube.PlaySound(_soundWaterStream);
            _soundTube.PlaySound(_soundSteam);

            _tubeDamage.SetActive(true);
            _tubeNormal.SetActive(false);
        } 
    }

    private void LicvidateDamageTube(WaterHealth EndWaterObjects)
    {
        if (!_isOnceActive)
        { 
            _particlesTube.StopParticles(_startWaterStream);
            _particlesTube.StopParticles(_startSteam);

            _soundTube.StopSound(_soundWaterStream);
            _soundTube.StopSound(_soundSteam);

            _particlesTube.StartParticles(_startWaterLeaking);
            _soundTube.PlaySound(_soundWaterLeaking);

            _fabricObjectTube.gameObject.SetActive(true);

            for (int i = 0; i < _intertactFabricObject.Length; i++)
            {
                _intertactFabricObject[i].SetActive(false);
            }
            base.IsWater = false;
            base.IsSteam = false;
            _isOnceActive = true;
            _phoneVictorine.IsActivatedVictorine = true;
        }
    }
}
