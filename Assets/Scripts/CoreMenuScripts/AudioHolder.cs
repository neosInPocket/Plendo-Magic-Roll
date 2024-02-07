using System.Linq;
using UnityEngine;

public class AudioHolder : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;

    private void Awake()
    {
        var data = GameObject.FindObjectsOfType<AudioHolder>();
        var custon = data.FirstOrDefault(x => x.gameObject.scene.name == "DontDestroyOnLoad");

        if (custon != null && custon != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        soundSource.enabled = SavingManager.Manager.enableMusic;
    }

    public bool Toggle()
    {
        soundSource.enabled = !soundSource.enabled;
        SavingManager.Manager.enableMusic = soundSource.enabled;
        SavingManager.Save();
        return soundSource.enabled;
    }
}
