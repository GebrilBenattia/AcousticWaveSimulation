using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputParser : MonoBehaviour
{
    public InputField m_ObjectInputField;

    public SceneInputs SceneInputs;

    public enum Input
    {
        Frequency,
        CarSpeed,
        Power, 
        Impedance
    };

    public Input NewSimulationInput;

    void Awake()
    {
        m_ObjectInputField = GetComponent<InputField>();
    }

    // M�thode appel�e lorsqu'un bouton est press�
    public void OnSubmitButtonPressed()
    {
        if (m_ObjectInputField != null)
        {
            float inputValue = 0f;
            if (float.TryParse(m_ObjectInputField.text, out inputValue))
            {
                Debug.Log("Valeur flottante entr�e : " + inputValue);
            }
            else
            {
                Debug.LogError("Veuillez entrer une valeur flottante valide.");
            }

            switch (NewSimulationInput) {
                case Input.Frequency:
                    SceneInputs.Frequency = inputValue;
                    break;
                case Input.CarSpeed:
                    SceneInputs.CarSpeed = inputValue;
                    break;
                case Input.Power:
                    SceneInputs.AcousticWavePower = inputValue;
                    break;
                case Input.Impedance:
                    SceneInputs.AcousticWaveImpedance = inputValue;
                    break;
                default:
                    break;
            }
        }
    }
}
