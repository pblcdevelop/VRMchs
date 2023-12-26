using Assets.App.Script.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particlesStreamFoam;
    [SerializeField] private Animator _animatiosCranPress;
    [SerializeField] private TriggerZoneController _triggerPreventerUnlock;
    private bool _isPreventered = false;

    private void OnEnable()
    {
        _triggerPreventerUnlock.TriggerExit += PreventerOff;
    }

    private void OnDisable()
    {
        _triggerPreventerUnlock.TriggerExit -= PreventerOff;
    }

    private void PreventerOff(Collider collision)
    {
        _isPreventered = true;
    }

    public void StartStream()
    {
        if (_isPreventered)
        {
            _particlesStreamFoam.Play();
            _animatiosCranPress.SetBool("Press", true);
        }
    }

    public void StopStream()
    {
            _animatiosCranPress.SetBool("Press", false);
            _particlesStreamFoam.Stop();
    }

}
