using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI = null;
    public GameObject SimulationConfigMenuUI = null;

    public GameObject SimulationConfigButton = null;

    public GameObject[] ObservatorValues = null;

    public Observator[] Observators = null;

    public GameObject[] ObservatorValuesButton = null;

    private bool m_WasConfigOpen = false;

    private bool m_WasOutDoorValueOpen = false;
    private bool m_WasInDoorValueOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (m_WasConfigOpen) {
            PauseMenuUI.SetActive(false);
            GameIsPaused = false;

            SimulationConfigMenuUI.SetActive(true);
            m_WasConfigOpen = false;
            SimulationConfigButton.SetActive(true);

            if (!Observators[0].InDoor) {
                if (m_WasOutDoorValueOpen)
                    ObservatorValues[0].SetActive(true);
            }
            if (Observators[1].InDoor) {
                if (m_WasInDoorValueOpen)
                    ObservatorValues[1].SetActive(true);
            }
            foreach (var item in ObservatorValuesButton) {
                item.SetActive(true);
            }

            m_WasOutDoorValueOpen = false;
            m_WasInDoorValueOpen = false;

            return;
        }
        SimulationConfigButton.SetActive(true);
        if (!Observators[0].InDoor)
        {
            if (m_WasOutDoorValueOpen)
                ObservatorValues[0].SetActive(true);
        }
        if (Observators[1].InDoor)
        {
            if (m_WasInDoorValueOpen)
                ObservatorValues[1].SetActive(true);
        }
        foreach (var item in ObservatorValuesButton)
        {
            item.SetActive(true);
        }

        m_WasOutDoorValueOpen = false;
        m_WasInDoorValueOpen = false;

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        if (SimulationConfigMenuUI.activeSelf) {
            SimulationConfigMenuUI.SetActive(false);
            m_WasConfigOpen = true;
        }
        SimulationConfigButton.SetActive(false);
        if (ObservatorValues[0].activeSelf){
            m_WasOutDoorValueOpen = true;
            ObservatorValues[0].SetActive(false);
        }
        if (ObservatorValues[1].activeSelf) {
            m_WasInDoorValueOpen = true;
            ObservatorValues[1].SetActive(false);
        }

        foreach (var item in ObservatorValuesButton) {
            item.SetActive(false);  
        }
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
