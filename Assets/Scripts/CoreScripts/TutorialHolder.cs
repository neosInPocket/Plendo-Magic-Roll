using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TutorialHolder : MonoBehaviour
{
	[SerializeField] private TMP_Text characterText;
	[SerializeField] private GameObject arrowPointer;
	private Action OnCompletedAction;
	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}

	public void StartAction(Action tutorialCompleted)
	{
		OnCompletedAction = tutorialCompleted;
		gameObject.SetActive(true);
		Touch.onFingerDown += Reaction;
		characterText.text = "WELCOME TO Plendo Magic Roll!";
	}

	private void Reaction(Finger finger)
	{
		Touch.onFingerDown -= Reaction;
		Touch.onFingerDown += Bulk;
		characterText.text = "LET'S CHECK YOUR REACTION? TAP ON THE MOVING BALLS TO POP THEM!";
	}

	private void Bulk(Finger finger)
	{
		Touch.onFingerDown -= Bulk;
		Touch.onFingerDown += Careful;
		characterText.text = "EACH BULK OF A CERTAIN COLOR FILLS ITS SCALE. FILL EVERY SCALE TO THE MAXIMUM VALUE TO WIN!";
		arrowPointer.SetActive(true);
	}

	private void Careful(Finger finger)
	{
		Touch.onFingerDown -= Careful;
		Touch.onFingerDown += GoodLuck;
		characterText.text = "BE CAREFUL! IF YOU MISS THE BALL OR OVERFILL THE SCALE, YOU WILL LOSE ONE LIFE";
		arrowPointer.SetActive(false);
	}

	private void GoodLuck(Finger finger)
	{
		Touch.onFingerDown -= GoodLuck;
		Touch.onFingerDown += EndPhrase;
		characterText.text = "GOOD LUCK AND HAVE FUN!";
	}

	private void EndPhrase(Finger finger)
	{
		Touch.onFingerDown -= EndPhrase;
		OnCompletedAction();

		if (gameObject != null)
		{
			gameObject.SetActive(false);
		}
	}
}
