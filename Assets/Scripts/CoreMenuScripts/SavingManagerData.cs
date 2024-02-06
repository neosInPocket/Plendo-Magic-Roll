using System;
using UnityEngine;

[Serializable]
public class SavingManagerData : MonoBehaviour
{
	public int playerStoreValue = 10;
	public bool playerFirstTime = true;
	public int[] upgrades = { 0, 0 };

	public int levelIndex = 1;
	public bool enableMusic = true;
	public bool enableEffects = true;
}
