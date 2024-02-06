using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class StoreHolder : MonoBehaviour
{
	[SerializeField] private StoreUpgradeData[] storeUpgradeDatas;
	[SerializeField] private TMP_Text descriptionText;
	[SerializeField] private TMP_Text canBuyText;
	[SerializeField] private List<Image> stars;
	[SerializeField] private Button buy;
	[SerializeField] private List<DiamodsRefresher> diamodsRefreshers;
	private int currentSelectedIndex;

	private void Start()
	{
		Select(0);
	}

	public void Select(int upgradeIndex)
	{
		currentSelectedIndex = upgradeIndex;

		var obj = storeUpgradeDatas[upgradeIndex];
		var detectedUpgrade = SavingManager.Manager.upgrades[upgradeIndex];
		var currentDiamonds = SavingManager.Manager.playerStoreValue;

		descriptionText.text = obj.Description;
		bool enoughDiamonds = currentDiamonds >= obj.Price;
		bool alreadyUpgradedToMax = detectedUpgrade >= 3;

		buy.interactable = enoughDiamonds && !alreadyUpgradedToMax;

		canBuyText.enabled = !enoughDiamonds;


		if (alreadyUpgradedToMax)
		{
			canBuyText.enabled = false;
		}

		RefreshDiamodsContainers();
		RefreshCurrentUpgradePoints(SavingManager.Manager.upgrades[currentSelectedIndex]);
	}

	public void Buy()
	{
		var obj = storeUpgradeDatas[currentSelectedIndex];

		SavingManager.Manager.playerStoreValue -= obj.Price;
		SavingManager.Manager.upgrades[currentSelectedIndex]++;
		SavingManager.Save();

		Select(currentSelectedIndex);
	}

	private void RefreshDiamodsContainers()
	{
		diamodsRefreshers.ForEach(x => x.RefreshDiamonds());
	}

	private void RefreshCurrentUpgradePoints(int upgradedValue)
	{
		stars.ForEach(x => x.enabled = false);

		for (int j = 0; j < upgradedValue; j++)
		{
			stars[j].enabled = true;
		}
	}
}
