using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUIView: MonoBehaviour
{
    [Header("UISound")]
    [SerializeField] private AudioSource _clickUI;
    [SerializeField] private AudioSource _swipeUI;
    [SerializeField] private AudioSource _congratulationUI;
    [SerializeField] private AudioSource _gameoverUI;
    [SerializeField] private AudioSource _errorUI;

    // UI Sound
    public void PlayClick()
    {
        _clickUI.Play();
    }
    public void PlaySwipeUI()
    {
        _swipeUI.Play();
    }

    public void CongratulationUI()
    {
        _congratulationUI.Play();
    }

    public void GameoverUI()
    {
        _gameoverUI.Play();
    }

    public void ErrorUI()
    {
        _errorUI.Play();
    }
}
