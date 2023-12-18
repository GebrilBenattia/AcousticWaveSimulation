using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationSettingsMenu : MonoBehaviour
{
    public GameObject SettingsMenuUI = null;

    public GameObject[] ObservatorValues = null;
    public GameObject[] ObservatorValuesButton = null;

    public Observator[] Observators = null;

    private bool m_WasOutDoorValueOpen = false;
    private bool m_WasInDoorValueOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSettingsMenu()
    {
        if (!SettingsMenuUI.activeSelf) {
            if (ObservatorValues[0].activeSelf) {
                ObservatorValues[0].SetActive(false);
                m_WasOutDoorValueOpen = true;
            }
            if (ObservatorValues[1].activeSelf) {
                ObservatorValues[1].SetActive(false);
                m_WasInDoorValueOpen = true;
            }
            foreach (var item in ObservatorValuesButton) {
                item.SetActive(false);
            }

            Time.timeScale = 0f;
            SettingsMenuUI.SetActive(true);
            return;
        }

        if (SettingsMenuUI.activeSelf) {
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

            Time.timeScale = 1f;
            SettingsMenuUI.SetActive(false);
            return;
        }
    }
}

