using UnityEngine;

public class SimulationInputsConfig : MonoBehaviour
{
    public SceneInputs SceneInputs;

    float m_Frequency = 0f;
    float m_CarSpeed = 0f;
    float m_WavePower = 0f;
    float m_WaveImpedance = 0f;

    bool m_FrequencyIsApplied = true;
    bool m_CarSpeedIsApplied = true;
    bool m_WavePowerIsApplied = true;
    bool m_WaveImpedanceIsApplied = true;

    public void ApplyInputs()
    {
        SceneInputs.Frequency = m_Frequency;
        SceneInputs.CarSpeed = m_CarSpeed;
        SceneInputs.AcousticWavePower = m_WavePower;
        SceneInputs.AcousticWaveImpedance = m_WaveImpedance;

        m_FrequencyIsApplied = true;
        m_CarSpeedIsApplied = true;
        m_WavePowerIsApplied = true;
        m_WaveImpedanceIsApplied = true;
    }
}
