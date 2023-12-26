using Assets.App.Script.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFiredHallPoint : ObjectPointBase
{
    [Header("Base")]
    [SerializeField] private TimerController _timerObject;
    [SerializeField] private FireHealth _fireHealth;

    [Header("Particles_Sound")]
    [SerializeField] private ObjectsParticles _particlesObjects;
    [SerializeField] private ObjectsSound _soundObjects;
    public bool _isFiredObject;

    [Space]
    [Header("FireMaximaze")]
    [SerializeField] private Animator _particlesMaximaze;
    [SerializeField] private bool _isParticlesMaximaze;

    [Space]
    [Header("TimeToActions")]
    [SerializeField] private float[] _timeToAction;

    //Particles and sound
    private int _particlesElectricity = 0;
    private int _particlesFuseSmoke = 1;
    private int _particleFire = 2;
    private int _particleWhiteSmoke = 3;

    private int _soundStartElectricity = 0;
    private int _soundElectricity = 1;
    private int _soundFuse = 2;
    private int _soundStartFire = 3;
    private int _soundFire = 4;
    private int _soundWaterFire = 5;

    private bool _isOnceSpark = false;
    private bool _isOnceSmoke = false;
    private bool _isOnceFire = false;

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
        if (!_isOnceSpark && _timerObject.CurrentTime >= _timeToAction[0])
        {
            StartSpark();
        }

        if (!_isOnceSmoke && _timerObject.CurrentTime >= _timeToAction[1])
        {
            StartFuse();
        }

        if (_isFiredObject && !_isOnceFire && _timerObject.CurrentTime >= _timeToAction[2])
        {
            StartFire();
        }
    }
    
    // Particles and Sound Activity
    private void StartSpark()
    {
        _isOnceSpark = true;
        base._isElectricity = true;
        _particlesObjects.StartParticles(_particlesElectricity);
        _soundObjects.PlaySound(_soundStartElectricity);
        _soundObjects.PlaySound(_soundElectricity);
    }

    private void StartFuse()
    {
        _isOnceSmoke = true;
        _particlesObjects.StartParticles(_particlesFuseSmoke);
        _soundObjects.PlaySound(_soundFuse);
    }

    private void StartFire()
    {
        _isOnceFire = true;
        base._isFired = true;
        _particlesObjects.StartParticles(_particleFire);
        _soundObjects.PlaySound(_soundStartFire);
        _soundObjects.PlaySound(_soundFire);
        MaximazeFire();
    }

    private void StartWhiteSmoke()
    {
        _particlesObjects.StartParticles(_particleWhiteSmoke);
        _soundObjects.PlaySound(_soundWaterFire);
    }

    private void MaximazeFire()
    {
        if (_isParticlesMaximaze && _particlesMaximaze != null)
        {
            _particlesMaximaze.SetBool("ParticlesMaximaze", true);
        }
    }

    public void StopSpark()
    {
        base._isElectricity = false;
        _particlesObjects.StopParticles(_particlesElectricity);
        _soundObjects.StopSound(_soundElectricity);
    }

    private void StopFuse()
    {
        _particlesObjects.StopParticles(_particlesFuseSmoke);
        _soundObjects.StopSound(_soundFuse);
    }

    private void StopFire()
    {
        base._isFired = false;
        _particlesObjects.StopParticles(_particleFire);
        _soundObjects.StopSound(_soundFire);
    }

    private void EndFired(FireHealth EndfireObjects)
    {
        if (base._isFired)
        {
            StopFuse();
            StopFire();
            StartWhiteSmoke();

            if (_isParticlesMaximaze && _particlesMaximaze != null)
            {
                _particlesMaximaze.enabled = false;
            }
        }
    }
}