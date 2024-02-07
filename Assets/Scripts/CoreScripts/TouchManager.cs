using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public class TouchManager : MonoBehaviour
{
	[SerializeField] private GameObject strikeEffect;
	[SerializeField] private Vector3 offset;

	private Action<BallColor> handler;
	private Action missHandler;

	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}

	public void Enable(bool value, Action<BallColor> ballColorHanlder = null, Action onMiss = null)
	{
		if (value)
		{
			handler = ballColorHanlder;
			missHandler = onMiss;
			Touch.onFingerDown += OnFingerDownScreen;
		}
		else
		{
			handler = null;
			missHandler = null;
			Touch.onFingerDown -= OnFingerDownScreen;
		}
	}

	private void OnFingerDownScreen(Finger finger)
	{
		Strike(ViewInfo.GetWorldPoint(finger.screenPosition) - offset);

		RaycastHit2D raycast = ViewInfo.RacyastFromPoint(finger.screenPosition);
		if (raycast.collider != null)
		{
			if (raycast.collider.TryGetComponent<BouncyBall>(out BouncyBall ball))
			{
				handler(ball.BallColor);
				ball.PopBall();
			}
		}
		else
		{
			missHandler?.Invoke();
		}
	}

	private void Strike(Vector2 position)
	{
		strikeEffect.gameObject.SetActive(false);
		strikeEffect.transform.position = position;
		strikeEffect.gameObject.SetActive(true);
	}

	private void OnDestroy()
	{
		Touch.onFingerDown -= OnFingerDownScreen;
	}
}
