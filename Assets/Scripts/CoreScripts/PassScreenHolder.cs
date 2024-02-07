using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PassScreenHolder : MonoBehaviour
{
    [SerializeField] private GameObject mainTextObject;
    private Action OnScreenTouchAction;

    private void Start()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
    }

    public void StartAction(Action screenTouch)
    {
        OnScreenTouchAction = screenTouch;

        if (mainTextObject != null)
        {
            mainTextObject.SetActive(true);
        }

        Touch.onFingerDown += OnScreenTouch;
    }

    private void OnScreenTouch(Finger finger)
    {
        Touch.onFingerDown -= OnScreenTouch;
        OnScreenTouchAction();

        mainTextObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Touch.onFingerDown -= OnScreenTouch;
    }
}
