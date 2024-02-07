using System.Collections.Generic;
using UnityEngine;

public class SetSFXValueEnabled : MonoBehaviour
{
	[SerializeField] private List<AudioSource> effectsSources;

	private void Start()
	{
		effectsSources.ForEach(x => x.enabled = SavingManager.Manager.enableEffects);
	}
}
