using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSink : MonoBehaviour
{
    [Header("Sink")]
    [SerializeField] private ParticleSystem _particlesWaterSink;
    [SerializeField] private ObjectsSound _objectsSound;

    public void WaterParticlesSinkOn()
    {
        if (_particlesWaterSink.isPlaying)
            return;
        _particlesWaterSink.Play();
        _objectsSound.PlaySound(0);
    }
    public void WaterParticlesSinkOff()
    {
        if (!_particlesWaterSink.isPlaying)
            return;
        _particlesWaterSink.Stop();
        _objectsSound.StopSound(0);
    }

    public void WaterOffTotal()
    {
        _particlesWaterSink.Stop();
        _objectsSound.StopSound(0);
        this.enabled = false;
    }
}
