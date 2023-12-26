using Assets.App.Script.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectFiredKitchenPoint : ObjectPointBase
{
    [Header("Base")]
    [SerializeField] private TimerController _timerObject;
    [SerializeField] private FireHealth _fireHealth;

    [Space]
    [Header("Particles/Sound Base")]
    [SerializeField] private ObjectsParticles _objectParticles;
    [SerializeField] private ObjectsSound _objectSound;

    [Space]
    [Header("Parametrs")]
    [SerializeField] private float _timeToFire;
    [SerializeField] private int _powerHealthFireStream;

    private bool _isOnceFired;
    private bool _isOnceStreamed;
    private bool _isFireStreamed;

    private int _particlesFire = 0;
    private int _particlesStreamFire = 1;
    private int _soundStartFire = 0;
    private int _soundFired = 1;
    private int _soundStreamFire = 2;

    private void OnEnable()
    {
        _fireHealth.EndFireObject += EndFired;
    }
    private void OnDisable()
    {
        _fireHealth.EndFireObject -= EndFired;
    }

    private void Update()
    {
        ParticlesSwitcher();
    }

    private void ParticlesSwitcher()
    {
        if (!_isOnceFired && _timerObject.CurrentTime >= _timeToFire)
        {
            StartFired();
        }
    }

    private void StartFired()
    {
        base._isFired = true;
        _isOnceFired = true;
        _objectParticles.StartParticles(_particlesFire);
        _objectSound.PlaySound(_soundStartFire);
        _objectSound.PlaySound(_soundFired);
    }

    private void StopFire()
    {
        if (base._isFired && !_isFireStreamed)
        {
            base._isFired = false;
            _objectParticles.StopParticles(_particlesFire);
            _objectSound.StopSound(_soundFired);  
        }
    }

    private void OnParticleCollision(GameObject objectWater)
    {
        if (objectWater.CompareTag("Water") && !_isFireStreamed && base._isFired)
        {
            StartStream();
        }
    }

    private void StartStream()
    {
        _isFireStreamed = true;
        _objectParticles.StopParticles(_particlesFire);
        _objectSound.StopSound(_soundFired);

        _objectParticles.StartParticles(_particlesStreamFire);
        _objectSound.PlaySound(_soundStreamFire);
        _fireHealth.MaximazeHealth(_powerHealthFireStream);
    }

    private void StopStream()
    {
        if (_isFireStreamed)
        {
            _isOnceStreamed = false;
            base._isFired = false;
            _objectParticles.StopParticles(_particlesStreamFire);
            _objectSound.StopSound(_soundStreamFire);
        }
    }

    private void EndFired(FireHealth EndfireObjects)
    {
        StopFire();
        StopStream();
    }
}

