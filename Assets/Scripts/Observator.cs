using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observator : MonoBehaviour
{
    [SerializeField] public bool InDoor = false;
    /*[HideInInspector]*/ public float PerceivedVolume = 0f;
    /*[HideInInspector]*/ public float PerceivedFrequency = 0f;
    /*[HideInInspector]*/ public float LastDistanceFromVehicule = 0f;
    /*[HideInInspector]*/ public bool IsLowPitched = false;

    public Sinewave wave = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        wave.transform.position = transform.position;
        wave.frequency = PerceivedFrequency;
    }
}
