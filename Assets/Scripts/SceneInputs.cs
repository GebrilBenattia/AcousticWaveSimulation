using UnityEngine;

public class SceneInputs : MonoBehaviour
{
    [SerializeField] public float Frequency = 0f;
    [SerializeField] public float CarSpeed = 0f;
    [SerializeField] public float AcousticWavePower = 0f;
    [SerializeField] public float AcousticWaveImpedance = 0f;

    public void Reset()
    {
        Frequency = 400f;
        CarSpeed = 14f;
        AcousticWavePower = 100f;
        AcousticWaveImpedance = 3000000f;
    }
}
