using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt : MonoBehaviour
{
    [SerializeField] private ParticleSystem _saltParticles;
    [SerializeField] private float _angleTrashold;

    private bool _isCheckSalt;

    void Update()
    {
        CheckSaltAngle();
    }

    private void CheckSaltAngle()
    {
        bool _isWaterCheck = CalculateAngle() < _angleTrashold;
        if (_isCheckSalt != _isWaterCheck)
        {
            _isCheckSalt = _isWaterCheck;

            if (!_isCheckSalt)
            {
                StartSaltParticles();
            }
            else
            {
                EndSaltParticles();
            }
        }
    }

    private float CalculateAngle()
    {
        return Vector3.Angle(transform.up, Vector3.up);
    }

    private void StartSaltParticles()
    {
        _saltParticles.Play();
    }

    private void EndSaltParticles()
    {
        _saltParticles.Stop();
    }
}
