using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PhoneController : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private ObjectsSound _objectsSound;
    [SerializeField] private GameObject _victorineUI;
    [SerializeField] private Victorine _victorineController;
    [SerializeField] private Animator _pushButtonAnim;

    [Space]
    [Header("Functions")]
    [SerializeField] private XRGripButton _phoneButtonKeyboard;

    [Space]
    [Header("TimeToVictorine")]
    [SerializeField] private float _timeToVictorine;

    private bool _isActivatedVictorine;

    public bool IsActivatedVictorine
    {
        get => _isActivatedVictorine;
        set
        {
            _isActivatedVictorine = value;
        }
    }

    private int _phoneGrabTubeSound = 0;
    private int _phoneGudokLongSound = 1;
    private int _phoneConnectAbonentSound = 2;
    private int _phoneNotAbonentSound = 3;

    private void Start()
    {
        _phoneButtonKeyboard.enabled = false;
        _isActivatedVictorine = false;
        _victorineUI.SetActive(false);
    }

    public void PhoneTubeOutPhone()
    {
        _phoneButtonKeyboard.enabled = true;
        _objectsSound.PlaySound(_phoneGrabTubeSound);
        _objectsSound.PlaySound(_phoneGudokLongSound);
    }

    public void PhoneTubeInPhone()
    {
        _phoneButtonKeyboard.enabled = false;
        _victorineUI.SetActive(false);

        _objectsSound.PlaySound(_phoneGrabTubeSound);
        _objectsSound.StopSound(_phoneGudokLongSound);
        _objectsSound.StopSound(_phoneConnectAbonentSound);
        _objectsSound.StopSound(_phoneNotAbonentSound);
    }

    public void PushKeyboardPhoneButton()
    {
        _objectsSound.StopSound(_phoneGudokLongSound);
        CheckPointPhone();
        _pushButtonAnim.SetBool("PushButton", true);
    }

    private IEnumerator WaitToEndSound()
    {
        yield return new WaitForSeconds(_timeToVictorine);
        _victorineUI.SetActive(true);
        _victorineController.IsActivateVictorine = true;
    }

    private void CheckPointPhone()
    {
        if (IsActivatedVictorine)
        {
            _objectsSound.PlaySound(_phoneConnectAbonentSound);
            StartCoroutine(WaitToEndSound());
        }
        if (!IsActivatedVictorine)
        {
            _objectsSound.PlaySound(_phoneNotAbonentSound);
        }
    }
}
