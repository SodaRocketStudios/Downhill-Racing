using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField]
    private WheelCollider[] wheelColliders;

    [SerializeField]
    private float maxSteerAngle = 10;

    private void Update()
    {
        Steer();
    }

    private void Steer()
    {
        for(int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].steerAngle = maxSteerAngle*(Input.GetAxis("Horizontal"));
        }
    }
}
