using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public class TouchManager : MonoBehaviour
{
	private Action<BallColor> handler;

	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}

	public void Enable(bool value, Action<BallColor> ballColorHanlder = null)
	{
		if (value)
		{
			handler = ballColorHanlder;
			Touch.onFingerDown += OnFingerDownScreen;
		}
		else
		{
			handler = null;
			Touch.onFingerDown -= OnFingerDownScreen;
		}
	}

	private void OnFingerDownScreen(Finger finger)
	{
		RaycastHit2D raycast = ViewInfo.RacyastFromPoint(finger.screenPosition);
		if (raycast.collider != null)
		{
			if (raycast.collider.TryGetComponent<BouncyBall>(out BouncyBall ball))
			{
				handler(ball.BallColor);
			}
		}
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= OnFingerDownScreen;
	}
}
