using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.App.Script.Manager;
using System;

public class MenuManager : MonoBehaviour
{
    [Header("Player and Trigger")]
    [SerializeField] private UIMenuView _uiMenu;

    public void LoadLevel()
    {
        _uiMenu.CheckField();
        if (_uiMenu.IsLoadLevel)
        {
            _uiMenu.CloseRegistrationsWindowAndStartGame();
            SceneManager.LoadSceneAsync("MchsVRScene");
        }
    }

    public void CloseApp()
    {
        DataHolder.UIAfterGame = false;
        Application.Quit();
    }
}

