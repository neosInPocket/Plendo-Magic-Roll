using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHolder : MonoBehaviour
{
	[SerializeField] private TouchManager touchManager;
	[SerializeField] private ColorResulter colorResulter;
	[SerializeField] private PassScreenHolder passScreenHolder;
	[SerializeField] private int scorePerCoin;
	[SerializeField] private Resulter resulter;
	[SerializeField] private TMP_Text levelIndexHolder;
	[SerializeField] private TutorialHolder tutorialHolder;
	[SerializeField] private string gameSceneName;
	[SerializeField] private string menuSceneName;
	private int score = 0;
	private int levelScore => (int)(10 * Mathf.Log(Mathf.Sqrt(SavingManager.Manager.levelIndex) + 2));
	private int coinsAfter => (int)(10 * Mathf.Log(Mathf.Pow(SavingManager.Manager.levelIndex, 2) + 2) + 12);

	private void Start()
	{
		levelIndexHolder.text = "LEVEL " + SavingManager.Manager.levelIndex.ToString();

		if (SavingManager.Manager.playerFirstTime)
		{
			SavingManager.Manager.playerFirstTime = false;
			SavingManager.Save();
		}
		else
		{

		}
	}

	private void OnTutorialCompleted()
	{

	}

	private void OnCountEnd()
	{

	}

	private void OnCoinEntered()
	{

	}

	private void CheckCurrentScore()
	{

	}

	private void Win()
	{

	}

	private void Lose()
	{

	}

	private void ObstacleEntered()
	{

	}

	private void OnDestroy()
	{

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
