using UnityEngine;
using Assets.App.Script.Manager;
using TMPro;

public class UIMenuView : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private TriggerZoneController _triggerZone;
    [SerializeField] private SoundUIView _soundUI;

    [Space]
    [Header("AnimationsUI")]
    [SerializeField] private Animator _registrationsWindow;
    [SerializeField] private Animator _endScenarioWindow;
    [SerializeField] private GameObject _circleLoading;

    [Space]
    [Header("PositionZone")]
    [SerializeField] private GameObject _circlePositionZone;
    [SerializeField] private Animator _registrationsZone;

    [Space]
    [Header("PlayerInformationsField")]
    [SerializeField] private TMP_InputField _firstNameIF;
    [SerializeField] private TMP_InputField _lastNameIF;
    [SerializeField] private string _firstName;
    [SerializeField] private string _lastName;

    [Space]
    [Header("Frame and Button")]
    [SerializeField] private GameObject _errorFirstName;
    [SerializeField] private GameObject _errorLastName;
    [SerializeField] private GameObject _errorGameMode;

    //[Space]
    //[Header("GameMode")]
    //[SerializeField] private TMP_Dropdown _gameModeSelected;

    public bool IsLoadLevel => _isLoadLevel;
    private bool _isLoadLevel = false;

    private void OnEnable()
    {
        _triggerZone.TriggerEntered += OpenRegistrationsWindow;
        _triggerZone.TriggerExit += CloseRegistrationsWindow;
    }

    private void OnDisable()
    {
        _triggerZone.TriggerEntered -= OpenRegistrationsWindow;
        _triggerZone.TriggerExit += CloseRegistrationsWindow;
    }

    private void Update()
    {
        ChekcLoadingScore();
    }

    private void OpenRegistrationsWindow(Collider collision)
    {
        _registrationsWindow.SetBool("OpenCloseSwitcher", true);
        _registrationsZone.SetBool("RegistrationsZone", true);
        _soundUI.PlaySwipeUI();
    }

    private void CloseRegistrationsWindow(Collider collision)
    {
        _registrationsWindow.SetBool("OpenCloseSwitcher", false);
        _registrationsZone.SetBool("RegistrationsZone", false);
        _soundUI.PlaySwipeUI();
    }

    private void ChekcLoadingScore()
    {
        if (DataHolder.UIAfterGame == true)
        {
            OpenEndWindow();
        }
    }

    private void OpenEndWindow()
    {
        _endScenarioWindow.SetBool("OpenCloseSwitcher", true);
        _soundUI.PlaySwipeUI();
        _circlePositionZone.SetActive(false);
    }

    public void CloseScoreWindows()
    {
        DataHolder.UIAfterGame = false;
        _soundUI.PlaySwipeUI();
        _endScenarioWindow.SetBool("OpenCloseSwitcher", false);
        _circlePositionZone.SetActive(true);
    }

    public void CloseRegistrationsWindowAndStartGame()
    {
        _registrationsWindow.SetBool("OpenCloseSwitcher", false);
        _circlePositionZone.SetActive(false);
        _circleLoading.SetActive(true);
    }

    public void UpdateInputs()
    {
        _firstName = _firstNameIF.text;
        _lastName = _lastNameIF.text;
    }

    public void CheckField()
    {
        UpdateInputs();

        if (_firstName == string.Empty)
        {
            _errorFirstName.SetActive(true);
            _soundUI.ErrorUI();
        }
        else
        {
            _errorFirstName.SetActive(false);
        }

        if (_lastName == string.Empty)
        {
            _errorLastName.SetActive(true);
            _soundUI.ErrorUI();
        }
        else
        {
            _errorLastName.SetActive(false);
        }

        if (_firstName != string.Empty && _lastName != string.Empty)
        {
            SelectMode();
        }
    }

    private void SelectMode()
    {
        _isLoadLevel = true;
    }
}