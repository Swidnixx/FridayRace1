using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingScript : MonoBehaviour
{
    public WheelBase[] wheels;
    public Rigidbody rb;
    public float motorTorque = 500;
    public float maxSteerAngle = 30;

    private void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");

        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = accel * motorTorque;
            wheel.wheelCollider.steerAngle = steer * maxSteerAngle;
        }
    }
}
