using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameView : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private SoundUIView _soundUI;
    
    [Space]
    [Header("FloatingWindows")]
    [SerializeField] private Animator _floatingWindow;
    [SerializeField] private Animator _effectFloatingWindow;
    
    [Space]
    [Header("Container")]
    [SerializeField] private GameObject[] _containerUI;

    [Space]
    [Header("Text")]
    [SerializeField] private TMP_Text _countErrorText;
    [SerializeField] private string[] _errorText;

    private int _congradulations = 0;
    private int _error = 1;

    // Open/Close Floating Window
    public void OpenFloatingdWindow()
    {
        _floatingWindow.SetBool("SwitcherFloatingUI", true);
        _soundUI.PlaySwipeUI();
    }

    public void CloseFloatingdWindow()
    {
        _floatingWindow.SetBool("SwitcherFloatingUI", false);
        _soundUI.PlaySwipeUI();
    }

    // Open/Close Died effect
    public void OpenDiedEffect()
    {
        _effectFloatingWindow.SetBool("DiedEffect", true);
    }
    public void CloseDiedEffect()
    {
        _effectFloatingWindow.SetBool("DiedEffect", false);
    }

    // Open end Container
    public void OpenContainerCongratulation()
    {
        _containerUI[_congradulations].SetActive(true);
    }


    // Open/Close Error container
    public void OpenContainerError(int value)
    {
        _containerUI[_error].SetActive(true);
        _countErrorText.text = _errorText[value];
    }

    public void CloseContainerError()
    {
        _containerUI[_error].SetActive(false);
    }
}

