using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public class ShowKeyboard : MonoBehaviour
{
    private TMP_InputField _inputField;
    void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onSelect.AddListener(x => OpenKeyboard());
    }

    public void OpenKeyboard()
    {
        NonNativeKeyboard.Instance.InputField = _inputField;
        NonNativeKeyboard.Instance.PresentKeyboard(_inputField.text);
        StartCoroutine(CheckShiftCoroutine());
    }
    private IEnumerator CheckShiftCoroutine()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        if (string.IsNullOrEmpty(_inputField.text))
            NonNativeKeyboard.Instance.Shift(true);
    }

    //private void KeyboardOnTextUpdated(string value)
    //{
    //    if (NonNativeKeyboard.Instance.InputField != _inputField)
    //        return;
    //    _curValue = value;
    //    Debug.Log($"KeyboardOnTextUpdated {_curValue}");
    //}
    //private void OnEnable()
    //{
    //    NonNativeKeyboard.Instance.OnTextUpdated += KeyboardOnTextUpdated;
    //    NonNativeKeyboard.Instance.OnTextSubmitted += KeyboardOnTextSubmitted;
    //    NonNativeKeyboard.Instance.OnClosed += KeyboardOnClosed;
    //}
    //private void OnDisable()
    //{
    //    NonNativeKeyboard.Instance.OnTextUpdated -= KeyboardOnTextUpdated;
    //    NonNativeKeyboard.Instance.OnTextSubmitted -= KeyboardOnTextSubmitted;
    //    NonNativeKeyboard.Instance.OnClosed -= KeyboardOnClosed;
    //}
    //private void KeyboardOnClosed(object sender, System.EventArgs e)
    //{
    //    Debug.Log("KeyboardOnClosed");
    //    UpdateInputField();
    //}
    //private void KeyboardOnTextSubmitted(object sender, System.EventArgs e)
    //{
    //    Debug.Log("KeyboardOnTextSubmitted");
    //    UpdateInputField();
    //}
    //private void UpdateInputField()
    //{
    //    if(NonNativeKeyboard.Instance.InputField == _inputField)
    //    {
    //        _inputField.text = _curValue;
    //        _inputField.text = _curValue;
    //        _inputField.text = _curValue;
    //        _inputField.text = _curValue;
    //        Debug.Log("UpdateInputField");
    //    }
    //    else
    //    {
    //        Debug.Log("NOT UpdateInputField");
    //    }
    //}
}
