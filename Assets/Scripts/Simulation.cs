using UnityEngine;

public class Simulation : MonoBehaviour
{
    [SerializeField] private SceneInputs m_Inputs = null;
    [SerializeField] private Vehicule m_Car = null;
    [SerializeField] private Observator[] m_Observators = null;

    private const float m_AirImpedance = 414f; // Pa s/m
    private const float m_WaveCelerityInAir = 343f; // m/s

    [SerializeField] public float Transmission = 0f;

    private const float m_I0 = 1.1e-12f;

    void Start()
    {
        m_Car.Speed = m_Inputs.CarSpeed;

        m_Observators[0].LastDistanceFromVehicule = Vector3.Distance(m_Car.transform.position, m_Observators[0].transform.position);
    }

    float GetTransmission()
    {
        float R = ((m_AirImpedance - m_Inputs.AcousticWaveImpedance) / (m_AirImpedance + m_Inputs.AcousticWaveImpedance)) * ((m_AirImpedance - m_Inputs.AcousticWaveImpedance) / (m_AirImpedance + m_Inputs.AcousticWaveImpedance));

        return (1f - R);
    }

    float GetIntensity(Vector3 Pos)
    {
        float Radius = Vector3.Distance(Pos, m_Car.transform.position);

        float I = m_Inputs.AcousticWavePower / (4f * Mathf.PI * (Radius*Radius));

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
            Observator.PerceivedFrequency = m_Inputs.Frequency * (m_WaveCelerityInAir / (m_WaveCelerityInAir - m_Car.Speed)); // if f' < f low pitched
        else
            Observator.PerceivedFrequency = m_Inputs.Frequency * (m_WaveCelerityInAir / (m_WaveCelerityInAir + m_Car.Speed)); // if f' > f high pitched
    }

    bool IsCarGettingCloser(Vehicule Car, Observator Observator)
    {
        float CurrentDistance = Vector3.Distance(Observator.transform.position, Car.transform.position);

        if (CurrentDistance < Observator.LastDistanceFromVehicule) {
            //Debug.Log("CLOSER");
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

    void Update()
    {
        Transmission = GetTransmission();

        m_Car.Speed = m_Inputs.CarSpeed;

        foreach (var observator in m_Observators)
        {
            GetVolume(observator);
            GetPerceivedFrequency(observator);
            GetPitchType(observator);
        }
    }
}