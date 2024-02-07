using UnityEngine;
using UnityEngine.UI;

public class SettingsHolder : MonoBehaviour
{
    [SerializeField] private Image musicSwitchButton;
    [SerializeField] private Image sfxSwitchButton;
    [SerializeField] private Color disabledColor;
    private AudioHolder audioHolder;

    private void Start()
    {
        audioHolder = GameObject.FindFirstObjectByType<AudioHolder>();
        bool musicEnabled = SavingManager.Manager.enableMusic;
        bool sfxEnabled = SavingManager.Manager.enableEffects;

        if (musicEnabled)
        {
            musicSwitchButton.color = Color.white;
        }
        else
        {
            musicSwitchButton.color = disabledColor;
        }

        if (sfxEnabled)
        {
            sfxSwitchButton.color = Color.white;
        }
        else
        {
            sfxSwitchButton.color = disabledColor;
        }
    }

    public void ToggleMusic()
    {
        bool enabled = audioHolder.Toggle();
        if (enabled)
        {
            musicSwitchButton.color = Color.white;
        }
        else
        {
            musicSwitchButton.color = disabledColor;
        }
    }

    public void ToggleSFX()
    {
        if (sfxSwitchButton.color == Color.white)
        {
            sfxSwitchButton.color = disabledColor;
            SavingManager.Manager.enableEffects = false;
        }
        else
        {
            sfxSwitchButton.color = Color.white;
            SavingManager.Manager.enableEffects = true;
        }

        SavingManager.Save();
    }
}
