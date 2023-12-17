using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observator : MonoBehaviour
{
    [SerializeField] public bool InDoor;
    [HideInInspector] public float PerceivedVolume;
    [HideInInspector] public float PerceivedFrequency;
    [HideInInspector] public float LastDistanceFromVehicule;
    [HideInInspector] public bool IsLowPitched;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
