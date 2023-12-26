using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidWater : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private Liquid _waterVolume;

    [Space]
    [Header("Liquid")]
    [SerializeField] private ParticleSystem _particlesWaterFoam;

    [Space]
    [Header("Parametrs")]
    [SerializeField] private float _timeWaterTrashold;
    [SerializeField] private float _timeRefilingWater;
    [SerializeField] private float _angleWaterTrashold;
    [SerializeField] private float _minFillWater;
    [SerializeField] private float _maxFillWater;

    private bool _isWaterParticlesActive;
    private bool _isWaterFill;
    public float FillWater
    {
        get => _waterVolume.FillAmount;
        set
        {
            _waterVolume.FillAmount = value;
        }
    }

    private void Awake()
    {
        _isWaterParticlesActive = false;
    }

    private void Update()
    {
        CheckWaterAngle();
        UpdateFillWater();
    }

    private void CheckWaterAngle()
    {
        bool _isWaterCheck = CalculateAngle() < _angleWaterTrashold;
        if (_isWaterParticlesActive != _isWaterCheck)
        {
            _isWaterParticlesActive = _isWaterCheck;

            if (!_isWaterParticlesActive)
            {
                StartWaterParticles();
                _isWaterFill = true;
            }
            else
            {
                EndWaterParticles();
                _isWaterFill = false;
            }
        }
    }

    private void UpdateFillWater()
    {
        if (_isWaterFill && FillWater <= _minFillWater)
        {
            FillWater += _timeWaterTrashold * Time.deltaTime;
        }

        if (FillWater >= _minFillWater)
        {
            EndWaterParticles();
        }
    }

    private void StartWaterParticles()
    {
        _particlesWaterFoam.Play();
    }

    public void EndWaterParticles()
    {
        _particlesWaterFoam.Stop();
    }

    private float CalculateAngle()
    {
        return Vector3.Angle(transform.up, Vector3.up);
    }

    public void RefillingWater()
    {
        if (FillWater >= _maxFillWater)
        {
            FillWater -= _timeRefilingWater * Time.deltaTime;
        }
    }
}
