using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandAnimationsController : MonoBehaviour
{
    [SerializeField] private InputActionProperty _triggerActions;
    [SerializeField] private InputActionProperty _gripActions;

    [SerializeField] private Animator _handAnimator;

    private void Awake()
    {
             
    }

    void Update()
    {
        AnimateHand();
    }


    private void AnimateHand()
    {
        float triggerValue = _triggerActions.action.ReadValue<float>();
        float gripValue = _gripActions.action.ReadValue<float>();

        _handAnimator.SetFloat("Trigger", triggerValue);
        _handAnimator.SetFloat("Grip", gripValue);
    }
}
