using System.Linq;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainHolder : MonoBehaviour
{
	[SerializeField] private TouchManager touchManager;
	[SerializeField] private BallsSpawner ballsSpawner;
	[SerializeField] private PassScreenHolder passScreenHolder;
	[SerializeField] private Resulter resulter;
	[SerializeField] private TMP_Text levelIndexHolder;
	[SerializeField] private TutorialHolder tutorialHolder;
	[SerializeField] private string gameSceneName;
	[SerializeField] private string menuSceneName;
	[SerializeField] private Image[] fillImages;
	[SerializeField] private float[] speeds;
	[SerializeField] private Image[] healthImages;
	[SerializeField] private Color alphaColor;
	private int[] scores = { 0, 0, 0 };
	private int levelScore;
	private int levelReward;
	private int currentHealth = 0;

	private void Start()
	{
		currentHealth = SavingManager.Manager.upgrades[0];
		RefreshHealthImages();
		levelScore = (int)(10 * Mathf.Log(Mathf.Sqrt(SavingManager.Manager.levelIndex) + 0.5f));
		levelReward = (int)(10 * Mathf.Log(Mathf.Pow(SavingManager.Manager.levelIndex, 2) + 2) + 12);
		RefreshImages();

		levelIndexHolder.text = "LEVEL " + SavingManager.Manager.levelIndex.ToString();


		if (SavingManager.Manager.playerFirstTime)
		{
			SavingManager.Manager.playerFirstTime = false;
			SavingManager.Save();

			tutorialHolder.StartAction(TutorialEndHandler);
		}
		else
		{
			TutorialEndHandler();
		}
	}

	private void RefreshHealthImages()
	{
		for (int i = 0; i < 3; i++)
		{
			healthImages[i].color = alphaColor;
		}

		for (int i = 0; i < currentHealth; i++)
		{
			healthImages[i].color = Color.white;
		}
	}

	private void OnBallTouch(BallColor ballColor)
	{
		if (scores[(int)ballColor] >= levelScore)
		{
			TakeDamage();
		}
		else
		{
			scores[(int)ballColor]++;
		}

		fillImages[(int)ballColor].fillAmount = (float)scores[(int)ballColor] / (float)levelScore;
		var fillCounter = 0;

		for (int i = 0; i < scores.Length; i++)
		{
			if (scores[i] >= levelScore)
			{
				fillCounter++;
			}
		}

		if (fillCounter == scores.Length)
		{
			WinLevel();
		}
	}

	private void RefreshImages()
	{
		for (int i = 0; i < 3; i++)
		{
			fillImages[i].fillAmount = (float)scores[i] / (float)levelScore;
		}
	}

	private void TakeDamage()
	{
		currentHealth--;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			LoseLevel();
		}

		RefreshHealthImages();
	}

	private void TutorialEndHandler()
	{
		passScreenHolder.StartAction(AfterTapHandler);
	}

	private void AfterTapHandler()
	{
		ballsSpawner.Enable(speeds[SavingManager.Manager.upgrades[1]]);
		touchManager.Enable(true, OnBallTouch, TakeDamage);
	}

	private void WinLevel()
	{
		touchManager.Enable(false);
		resulter.StartResultAction(true, levelReward);

		SavingManager.Manager.levelIndex++;
		SavingManager.Manager.playerStoreValue += levelReward;
		SavingManager.Save();
	}

	private void LoseLevel()
	{
		touchManager.Enable(false);

		resulter.StartResultAction(false, 0);
	}

	public void ProgressLevel()
	{
		SceneManager.LoadScene(gameSceneName);
	}

	public void Return()
	{

		SceneManager.LoadScene(menuSceneName);
	}
}
