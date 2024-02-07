using System;
using UnityEngine;

[Serializable]
public class SavingManagerData
{
	public int playerStoreValue = 20;
	public bool playerFirstTime = true;
	public int[] upgrades = { 1, 0 };

	public int levelIndex = 1;
	public bool enableMusic = true;
	public bool enableEffects = true;
}
