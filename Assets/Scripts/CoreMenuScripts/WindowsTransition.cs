using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsTransition : MonoBehaviour
{
    public void GoToMainGame()
    {
        SceneManager.LoadScene("NextGameScene");
    }
}
