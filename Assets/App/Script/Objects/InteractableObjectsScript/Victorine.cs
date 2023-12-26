using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Questions
{
    public string Text;
    public string[] Answers;
    [Range(0, 3)]
    public byte CorrectIndex;
}

public class Victorine : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] private Questions[] _questions;
    [SerializeField] private TMP_Text _questionsText;

    [Space]
    [Header("Answers")]
    [SerializeField] private Button[] _answerButtons;
    private TMP_Text[] _answerButtonText;

    private byte _currentIndex = 0;


    private bool _isActivateVictorine = false;
    public bool IsActivateVictorine
    {
        get => _isActivateVictorine;
        set
        {
            _isActivateVictorine = value;
        }
    }
    private void Awake()
    {
        var lenght = _answerButtons.Length;
        _answerButtonText = new TMP_Text[lenght];
        for (var i = 0; i < lenght; i++)
        {
            _answerButtonText[i] = _answerButtons[i].GetComponentInChildren<TMP_Text>();
        }
    }

    private void Start()
    {
        SetQestions();
        for (byte i=0; i < _answerButtons.Length; i++)
        {
            var index = i;
            _answerButtons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnButtonClick(byte index)
    {
        var correctIndex = _questions[_currentIndex].CorrectIndex;
        if (index == correctIndex)
        {
            _currentIndex++;
           if (_currentIndex > _questions.Length)
            {
                EndVictorine();
            }
            else
            {
                SetQestions();
            }
            Debug.Log("Correct");
        }
        else
        {
            _answerButtons[index].enabled = false;
            _answerButtons[index].image.color = Color.red;
            Debug.Log("Incorrect");
        }
    }

    private void SetQestions()
    {
        var currentQestions = _questions[_currentIndex];
        _questionsText.text = currentQestions.Text;
        for (var i = 0; i < _answerButtons.Length; i++)
        {
            var text = currentQestions.Answers[i];
            switch (i)
            {
                case 0:
                    _answerButtonText[i].text = $"1: {text}";
                    break;
                case 1:
                    _answerButtonText[i].text = $"2: {text}";
                    break;
                case 2:
                    _answerButtonText[i].text = $"3: {text}";
                    break;
                case 3:
                    _answerButtonText[i].text = $"4: {text}";
                    break;
            }
            _answerButtonText[i].text = text;
            }
    }

    private void EndVictorine()
    {
        _questionsText.text = "Вы заончили викторину!";
        for(var i = 0; i < _answerButtons.Length; i++)
        {
            _answerButtons[i].gameObject.SetActive(false);
        }
        Debug.Log("EndGame");
    }

    /*Questions and Answer
    Вопрос 1
    Вариант 1
    Вариант 2
    Вариант 3
    Вариант 4
     */

}
