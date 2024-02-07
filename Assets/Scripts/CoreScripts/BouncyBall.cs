using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BouncyBall : MonoBehaviour
{
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private Rigidbody2D rigid;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameObject[] popEffects;
	[SerializeField] private Sprite[] sprites;
	[SerializeField] private Material[] materials;
	public BallColor BallColor => currentBallColor;
	public bool Avaliable => !gameObject.activeSelf;
	private BallColor currentBallColor;
	private Vector2 currentSpeed;
	private float speedMagnitude;

	private void Update()
	{
		if (Avaliable) return;

		rigid.velocity = currentSpeed;
	}

	public void Initialize(BallColor ballColor, Vector2 position, float speed)
	{
		speedMagnitude = speed;
		gameObject.SetActive(true);
		spriteRenderer.enabled = true;
		circleCollider2D.enabled = true;
		rigid.constraints = RigidbodyConstraints2D.None;
		currentBallColor = ballColor;

		spriteRenderer.sprite = sprites[(int)ballColor];
		spriteRenderer.material = materials[(int)ballColor];

		transform.position = position;
		currentSpeed = GetRandomSpeed(speed);
	}

	private Vector2 GetRandomSpeed(float speedValue)
	{
		var randomAngle = Random.Range(0, 360f);
		var randomDirectionVector = new Vector2(Mathf.Cos(randomAngle * Mathf.PI / 180f), -Mathf.Sin(randomAngle * Mathf.PI / 180f));
		var result = speedValue * randomDirectionVector;
		return result;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.position.y > 0 && collision.transform.position.x == 0)
		{
			currentSpeed.y *= -1;
			return;
		}

		if (collision.transform.position.y < 0 && collision.transform.position.x == 0)
		{
			currentSpeed.y *= -1;
			return;
		}

		if (collision.transform.position.x > 0 && collision.transform.position.y == 0)
		{
			currentSpeed.x *= -1;
			return;
		}

		if (collision.transform.position.x < 0 && collision.transform.position.y == 0)
		{
			currentSpeed.x *= -1;
			return;
		}
	}

	public void PopBall()
	{
		StartCoroutine(PopEffect());
	}

	private IEnumerator PopEffect()
	{
		spriteRenderer.enabled = false;
		circleCollider2D.enabled = false;
		rigid.constraints = RigidbodyConstraints2D.FreezeAll;
		popEffects[(int)BallColor].SetActive(true);
		yield return new WaitForSeconds(1f);
		popEffects[(int)BallColor].SetActive(false);
		gameObject.SetActive(false);
		Initialize(currentBallColor, transform.position, speedMagnitude);
	}
}

public enum BallColor
{
	Red,
	Green,
	Blue
}
