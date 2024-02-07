using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resulter : MonoBehaviour
{
	[SerializeField] private TMP_Text rewardTextCaption;
	[SerializeField] private TMP_Text levelResultCaption;
	[SerializeField] private TMP_Text btnCaption;
	[SerializeField] private Animator animatorController;
	[SerializeField] private string gameSceneName;
	[SerializeField] private string menuSceneName;
	private Action OnHideAction;

	public void StartResultAction(bool win, int coinsAdded)
	{
		gameObject.SetActive(true);
		string btnTextCaption = default;
		string rewardTextCaption = default;
		string resultTextCaption = default;

		if (win)
		{
			btnTextCaption = "NEXT LEVEL";
			resultTextCaption = "GOOD JOB!";
		}
		else
		{
			btnTextCaption = "TRY AGAIN";
			resultTextCaption = "HAVE LUCK NEXT TIME..";
		}

		rewardTextCaption = "+" + coinsAdded.ToString();

		this.rewardTextCaption.text = rewardTextCaption;
		levelResultCaption.text = resultTextCaption;
		btnCaption.text = btnTextCaption;
	}

	public void MenuAction()
	{
		animatorController.SetTrigger("hideAction");
		OnHideAction = () => SceneManager.LoadScene(menuSceneName);
	}

	public void LevelAction()
	{
		animatorController.SetTrigger("hideAction");
		OnHideAction = () => SceneManager.LoadScene(gameSceneName);
	}

	public void HideAction()
	{
		gameObject.SetActive(false);
		OnHideAction();
	}
}
