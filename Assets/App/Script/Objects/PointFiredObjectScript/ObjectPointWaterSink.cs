using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPointWaterSink : ObjectPointBase
{
    [Header("Base")]
    [SerializeField] private TimerController _timerController;
    [SerializeField] private WaterHealth _waterHealth;

    [Space]
    [Header("Particles")]
    [SerializeField] private ObjectsParticles _particlesSink;
    [SerializeField] private ObjectsSound _soundSink;

    [Space]
    [Header("Parametrs")]
    [SerializeField] private int[] _timeToActions;

    private bool _isOnce = false;
    private bool _isActivatePoint = false;

    private int _particlesWaterStream = 0;

    private int _soundDamageTube = 0;
    private int _soundWaterStream = 1;

    private void OnEnable()
    {
        _waterHealth.EndWaterObjects += EndWater;
    }
    private void OnDisable()
    {
        _waterHealth.EndWaterObjects -= EndWater;
    }

    private void Update()
    {
        ParticlesActivateTube();
    }

    private void ParticlesActivateTube()
    {
        if (!_isOnce && _timerController.CurrentTime >= _timeToActions[0])
        {
            _isOnce = true;
            _isActivatePoint = true;
            _particlesSink.StartParticles(_particlesWaterStream);

            _soundSink.PlaySound(_soundDamageTube);
            _soundSink.PlaySound(_soundWaterStream);
        }
    }

    public void WaterLeverOff()
    {
        if (_isActivatePoint)
        {
            _particlesSink.StopParticles(_particlesWaterStream);
            _soundSink.StopSound(_soundWaterStream);
            _waterHealth.CurrentWaterHealth = 0;
        }
    }

    public void WaterLeverOn()
    {
        if (_isActivatePoint)
        {
            _particlesSink.StartParticles(_particlesWaterStream);
            _soundSink.PlaySound(_soundWaterStream);
            _waterHealth.CurrentWaterHealth = 1;
        }
    }

    private void EndWater(WaterHealth EndWaterObjects)
    {
        _particlesSink.StopParticles(_particlesWaterStream);
        _soundSink.StopSound(_soundWaterStream);
    }
}
