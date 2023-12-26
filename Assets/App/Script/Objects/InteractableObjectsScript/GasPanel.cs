using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class GasPanel : MonoBehaviour
{
    [SerializeField] private ParticleSystem _gasPanelFire;
    [SerializeField] private XRKnob _gasPanelKnob;

    private void Update()
    {
        //CheckValueGasPanel();
    }

    private void CheckValueGasPanel()
    {
        if (_gasPanelKnob.value <= 0.05)
        {
            FireGasPanelOn();
        }
        if (_gasPanelKnob.value >= 0.95)
        {
            FireGasPanelOff();
        }
    }

    public void FireGasPanelOn()
    {
        if (_gasPanelFire.isPlaying)
            return;
        _gasPanelKnob.value = 0;
        _gasPanelFire.Play(); 
    }

    public void FireGasPanelOff()
    {
        if (!_gasPanelFire.isPlaying)
            return;
        _gasPanelFire.Stop();
        _gasPanelKnob.value = 1;
    }
    public void FireGasPanelOffTotal()
    {
        _gasPanelFire.Stop();
        this.enabled = false;
    }
}
