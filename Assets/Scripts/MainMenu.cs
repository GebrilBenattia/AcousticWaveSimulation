using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BaseScene");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
