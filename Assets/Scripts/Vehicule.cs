using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicule : MonoBehaviour
{
    [HideInInspector] public float Speed;
    [HideInInspector] public AcousticWaveTransmitter WaveTransmitter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Speed * -1f * Time.deltaTime, 0f, 0f);
    }
}
