using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GasControl : MonoBehaviour
{
    [SerializeField] private List<GasPanel> _gasPanel;
    public event Action GasActivity;

    public void GasOff()
    {
        foreach (GasPanel gas in _gasPanel)
        {
            gas.FireGasPanelOffTotal();
        }

        GasActivity?.Invoke();
    }
}

