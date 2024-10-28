using UnityEngine;

public class Observator : MonoBehaviour
{
    [SerializeField] public bool InDoor = false;
    public float PerceivedVolume = 0f;
    public float PerceivedFrequency = 0f;
    public float LastDistanceFromVehicule = 0f;
    public bool IsLowPitched = false;
}
