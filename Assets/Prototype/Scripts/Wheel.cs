using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    private WheelCollider wheelCollider;
    private GameObject wheel;
    
    private void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
    }
}
