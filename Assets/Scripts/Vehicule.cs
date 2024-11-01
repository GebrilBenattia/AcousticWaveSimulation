using UnityEngine;

public class Vehicule : MonoBehaviour
{
    [HideInInspector] public float Speed = 0f;
    [SerializeField] public AcousticWaveTransmitter WaveTransmitter = null;
    [SerializeField] private Light m_Light = null;

    public GameObject StartPosObject;

    public float minIntensity = 0f; 
    public float maxIntensity = 300f;
    public float frequency = 1f;

    void Update()
    {
        float time = Time.time * frequency;
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.Abs(Mathf.Sin(time)));

        m_Light.intensity = intensity;

        transform.position += new Vector3(Speed * 1f * Time.deltaTime, 0f, 0f);
    }

    public void Replay()
    {
        transform.position = StartPosObject.transform.position;
    }
}
