using TMPro;
using UnityEngine;

public class DisplayValue : MonoBehaviour
{
    public TextMeshProUGUI TextMeshPro = null;

    public Observator Observator = null;

    public bool DisplayedInParameterMenu = false;

    public SceneInputs Inputs = null;

    public enum Value
    {
        Volume,
        Frequency,
        Pitch
    }

    public enum Parameters
    {
        Frequency,
        CarSpeed,
        WavePower,
        WaveImpedance
    }

    public Value ValueToPrint = Value.Volume;
    
    public Parameters ParametersToPrint = Parameters.Frequency;

    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        if (!DisplayedInParameterMenu) {
            switch(ValueToPrint) {
                case Value.Volume:
                    TextMeshPro.text = "Volume : " + Observator.PerceivedVolume + " dB";
                    break;
                case Value.Frequency:
                    TextMeshPro.text = "Frequency : " + Observator.PerceivedFrequency + " Hz";
                    break; 
                case Value.Pitch:
                    if (Observator.IsLowPitched)
                        TextMeshPro.text = "Lower Pitch";
                    else
                        TextMeshPro.text = "Higher Pitch";
                    break;
                default:
                    break;
            }
        }
        else {
            switch(ParametersToPrint) {
                case Parameters.Frequency:
                    TextMeshPro.text = "Current Frequency -> " + Inputs.Frequency + " Hz";
                    break;
                case Parameters.CarSpeed:
                    TextMeshPro.text = "Current CarSpeed -> " + Inputs.CarSpeed + " m/s";
                    break;
                case Parameters.WavePower:
                    TextMeshPro.text = "Current WavePower -> " + Inputs.AcousticWavePower + " W";
                    break;
                case Parameters.WaveImpedance:
                    TextMeshPro.text = "Current WaveImpedance -> " + Inputs.AcousticWaveImpedance + " Pa s/m";
                    break;
                default:
                    break;
                }
            }
    }
}
