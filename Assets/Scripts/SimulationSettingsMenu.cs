using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationSettingsMenu : MonoBehaviour
{
    public GameObject SettingsMenuUI = null;

    public GameObject[] ObservatorValues = null;
    public GameObject[] ObservatorValuesButton = null;

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
            foreach (var item in ObservatorValues) {
                item.SetActive(false);
            }
            foreach (var item in ObservatorValuesButton) {
                item.SetActive(false);
            }

            Time.timeScale = 0f;
            SettingsMenuUI.SetActive(true);
            return;
        }

        if (SettingsMenuUI.activeSelf) {
            foreach (var item in ObservatorValuesButton) {
                item.SetActive(true);
            }
            Time.timeScale = 1f;
            SettingsMenuUI.SetActive(false);
            return;
        }
    }
}

