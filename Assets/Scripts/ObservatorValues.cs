using UnityEngine;

public class ObservatorValues : MonoBehaviour
{
    public GameObject SimulationSettingsMenu = null;

    public GameObject[] ValuesPanel = null;
    public Observator[] Observator = null;

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
