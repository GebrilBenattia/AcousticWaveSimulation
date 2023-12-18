using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservatorValues : MonoBehaviour
{
    public GameObject SimulationSettingsMenu = null;

    public GameObject[] ValuesPanel = null;
    public Observator[] Observator = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowOutDoorPanel()
    {
        if (SimulationSettingsMenu.activeSelf)
            return;

        if (!ValuesPanel[0].activeSelf)
        {
            ValuesPanel[0].SetActive(true);
            return;
        }

        if (ValuesPanel[0].activeSelf)
        {
            ValuesPanel[0].SetActive(false);
            return;
        }
    }

    public void ShowInDoorPanel()
    {
        if (SimulationSettingsMenu.activeSelf)
            return;

        if (!ValuesPanel[1].activeSelf)
        {
            ValuesPanel[1].SetActive(true);
            return;
        }

        if (ValuesPanel[1].activeSelf)
        {
            ValuesPanel[1].SetActive(false);
            return;
        }
    }
}
