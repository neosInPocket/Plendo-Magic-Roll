using TMPro;
using UnityEngine;

public class DiamodsRefresher : MonoBehaviour
{
	[SerializeField] private TMP_Text amount;

	private void Start()
	{
		RefreshDiamonds();
	}

	public void RefreshDiamonds()
	{
		amount.text = SavingManager.Manager.playerStoreValue.ToString();
	}
}
