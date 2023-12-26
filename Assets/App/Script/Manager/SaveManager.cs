using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private ScenarioManager _scenarioManager;
    private int _saveNimberObject;

    public int SaveNumberObject
    {
        get => _saveNimberObject;
        set
        {
            LoadPointStage();
        }
    } 
  
    public void SavePointStage()
    {
        PlayerPrefs.SetInt("Stage", _scenarioManager.CurrentPoint);
    }

    public void LoadPointStage()
    {
        _saveNimberObject = PlayerPrefs.GetInt("Stage");
    }

    public void DeletePointStage()
    {
        PlayerPrefs.DeleteKey("Stage");
        Debug.Log("DeletedSavedStageData");
    }
}
