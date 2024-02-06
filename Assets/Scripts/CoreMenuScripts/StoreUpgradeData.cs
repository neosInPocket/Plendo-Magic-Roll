using System;
using UnityEngine;

[Serializable]
public class StoreUpgradeData
{
	[SerializeField] int price;
	[SerializeField] string description;
	[SerializeField] int upgradeIndex;

	public int Price => price;
	public string Description => description;
	public int UpgradeIndex => upgradeIndex;

}
