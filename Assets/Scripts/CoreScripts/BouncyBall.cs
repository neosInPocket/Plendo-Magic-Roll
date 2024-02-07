using System.Collections;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
	[SerializeField] private CircleCollider2D circleCollider2D;
	[SerializeField] private Rigidbody2D rigid;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameObject popEffect;
	[SerializeField] private Sprite[] sprites;
	[SerializeField] private Material[] materials;
	[SerializeField] private Vector2 randomSpeeds;
	public BallColor BallColor => currentBallColor;
	public bool Avaliable => !gameObject.activeSelf;
	private BallColor currentBallColor;
	private Vector2 screenSize;

	private void Start()
	{
		screenSize = ViewInfo.Screen;
	}


	public void Initialize(BallColor ballColor, Vector2 position)
	{
		spriteRenderer.enabled = true;
		circleCollider2D.enabled = true;
		rigid.constraints = RigidbodyConstraints2D.None;
		currentBallColor = ballColor;

		spriteRenderer.sprite = sprites[(int)ballColor];
		spriteRenderer.material = materials[(int)ballColor];

		transform.position = position;
		var randomAngle = Random.Range(0, 360f);
		var randomDirectionVector = new Vector2(Mathf.Cos(randomAngle * Mathf.PI / 180f), -Mathf.Sin(randomAngle * Mathf.PI / 180f));
		rigid.velocity = Random.Range(randomSpeeds.x, randomSpeeds.y) * randomDirectionVector;
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
		popEffect.SetActive(true);
		yield return new WaitForSeconds(1f);
		popEffect.SetActive(false);
		gameObject.SetActive(false);
	}
}

public enum BallColor
{
	Red,
	Green,
	Blue
}
