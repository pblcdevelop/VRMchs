using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsParticles : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _particlesObjects;
    
    public void StartParticles(int value)
    {
            _particlesObjects[value].Play();
    }

    public void StopParticles(int value)
    {
        _particlesObjects[value].Stop();
    }


}
