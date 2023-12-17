using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    [SerializeField] private SceneInputs m_Inputs;
    [SerializeField] private Vehicule m_Car;
    [SerializeField] private Observator[] m_Observators = null;

    [SerializeField] public float Transmission;

    private const float m_I0 = 1.1e-12f;


    // Start is called before the first frame update
    void Start()
    {
        m_Car.Speed = m_Inputs.CarSpeed;
        //m_Car.WaveTransmitter.WaveFrequency = m_Inputs.Frequency;
        //m_Car.WaveTransmitter.WavePower = m_Inputs.AcousticWavePower;
        //m_Car.WaveTransmitter.WaveImpedance = m_Inputs.AcousticWaveImpedance;

        m_Observators[0].LastDistanceFromVehicule = Vector3.Distance(m_Car.transform.position, m_Observators[0].transform.position);

        Transmission = 0f;
    }

    float GetTransmission()
    {
        float R = ((414f - m_Inputs.AcousticWaveImpedance) / (414f + m_Inputs.AcousticWaveImpedance)) * ((414f - m_Inputs.AcousticWaveImpedance) / (414f + m_Inputs.AcousticWaveImpedance));

        return (1f - R);
    }

    float GetIntensity(Vector3 Pos)
    {
        float Radius = Vector3.Distance(Pos, m_Car.transform.position);

        float I = 100f / (4f * Mathf.PI * (Radius*Radius));

        return I;
    }

    void GetVolume(Observator Observator)
    {
        float I = GetIntensity(Observator.transform.position);

        if (Observator.InDoor)
            I = I * Transmission;

        Observator.PerceivedVolume = 10f * Mathf.Log10(I / m_I0);
    }

    void GetPerceivedFrequency(Observator Observator)
    {
        if (IsCarGettingCloser(m_Car, Observator))
            Observator.PerceivedFrequency = m_Inputs.Frequency * (343f / (343f - m_Car.Speed)); // if f' < f low pitched
        else
            Observator.PerceivedFrequency = m_Inputs.Frequency * (343f / (343f + m_Car.Speed)); // if f' > f high pitched
    }

    bool IsCarGettingCloser(Vehicule Car, Observator Observator)
    {
        float CurrentDistance = Vector3.Distance(Observator.transform.position, Car.transform.position);

        if (Observator.LastDistanceFromVehicule > CurrentDistance) {
            Observator.LastDistanceFromVehicule = CurrentDistance;
            return true;
        }

        Observator.LastDistanceFromVehicule = CurrentDistance;
        return false;
    }

    void GetPitchType(Observator Observator)
    {
        if (Observator.PerceivedFrequency < m_Inputs.Frequency)
            Observator.IsLowPitched = true;
        else
            Observator.IsLowPitched = false;
    }

    // Update is called once per frame
    void Update()
    {
        Transmission = GetTransmission();

        //foreach (var observator in m_Observators)
        //{
        //    GetVolume(observator);
        //    GetPerceivedFrequency(observator);
        //    GetPitchType(observator);
        //}

        GetPerceivedFrequency(m_Observators[0]);
        GetPitchType(m_Observators[0]);

        if (m_Observators[0].IsLowPitched) {
            Debug.Log(m_Observators[0].PerceivedFrequency);
            Debug.Log("PLUS GRAVE");
        }
        else {
            Debug.Log(m_Observators[0].PerceivedFrequency);
            Debug.Log("PLUS AIGU");
        }
    }
}