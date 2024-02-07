using System.Collections.Generic;
using UnityEngine;

public class BallsSpawner : MonoBehaviour
{
	[SerializeField] private List<BouncyBall> startList;
	[SerializeField] private float topEdge;
	[SerializeField] private float bottomEdge;
	[SerializeField] private float circleRadius;
	private List<BouncyBall> currentList;

	private bool isEnabled;
	private Vector2 screenSize;

	private void Start()
	{
		screenSize = ViewInfo.Screen;
		currentList = startList;
	}

	public void Enable(float speed)
	{
		int randomColor = default;
		Vector2 position = default;
		int currentCounter = 0;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				position.x = Random.Range(-screenSize.x + circleRadius, screenSize.x - circleRadius);
				position.y = Random.Range(2 * screenSize.y * topEdge - screenSize.y - circleRadius, 2 * screenSize.y * bottomEdge - screenSize.y + circleRadius);
				currentList[currentCounter].Initialize((BallColor)i, position, speed);
				currentCounter++;
			}
		}
	}
}
