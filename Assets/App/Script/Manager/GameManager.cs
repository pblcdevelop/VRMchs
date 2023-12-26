using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Assets.App.Script.Manager;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private ScenarioManager _scenarioManager;
    [SerializeField] private SaveManager _saveManager;

    [Space]
    [Header("Controller")]
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private TimerController _globalTimerController;

    [Space]
    [Header("View")]
    [SerializeField] private UIGameView _uiGameView;
    [SerializeField] private SoundUIView _soundUI;

    private void Start()
    {
        StartGameScenario();
    }

    private void OnEnable()
    {
        _scenarioManager.ScenarioEndedTrue += EndGameScenario;
        _playerHealthController.PlayerDamage += ErorrObjectScenario;
    }

    private void OnDisable()
    {
        _scenarioManager.ScenarioEndedTrue -= EndGameScenario;
        _playerHealthController.PlayerDamage -= ErorrObjectScenario;
    }


    private void StartGameScenario()
    {
        _scenarioManager.StartScenario(0);
        _globalTimerController.StartTimer();
    }

    private void EndGameScenario()
    {
        UICongratulation();    
    }

    private void ErorrObjectScenario()
    {
            UIWindowError();     
    }

    private void UICongratulation()
    {
        _globalTimerController.StopTimer();
        _soundUI.CongratulationUI();

        _uiGameView.OpenFloatingdWindow();
        _uiGameView.OpenContainerCongratulation();
    }

    private void UIWindowError()
    {
        _soundUI.ErrorUI();
        _uiGameView.OpenFloatingdWindow();
        _uiGameView.OpenDiedEffect();
        _uiGameView.OpenContainerError(_playerHealthController.DamageType);
    }

    public void ExitMenuScene()
    {
        _saveManager.DeletePointStage();
        DataHolder.UIAfterGame = true;
        SceneManager.LoadScene("SpaceVRScene");
    }
}
