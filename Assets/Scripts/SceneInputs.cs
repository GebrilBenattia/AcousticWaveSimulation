using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInputs : MonoBehaviour
{
    [SerializeField] public float Frequency = 0f;
    [SerializeField] public float CarSpeed = 0f;
    [SerializeField] public float AcousticWavePower = 0f;
    [SerializeField] public float AcousticWaveImpedance = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Frequency = 400f;
        CarSpeed = 14f;
        AcousticWavePower = 100f;
        AcousticWaveImpedance = 3000000f;
    }
}
