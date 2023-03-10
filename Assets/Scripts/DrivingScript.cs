using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingScript : MonoBehaviour
{
    public WheelBase[] wheels;
    public Rigidbody rb;
    public float motorTorque = 500;
    public float maxSteerAngle = 30;
    public float brakeTorque = 1500;

    public Transform centerOfMass;

    public float maxSpeed = 90;

    float speed;

    private void Start()
    {
        rb.centerOfMass = centerOfMass.localPosition;
    }

    private void Update()
    {
        speed = rb.velocity.magnitude * 3.6f;

        float accel = Input.GetAxis("Vertical");
        if (speed >= maxSpeed)
            accel = 0;
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.brakeTorque = brake * brakeTorque;
            wheel.wheelCollider.motorTorque = accel * motorTorque;

            if (wheel.frontWheel)
            {
                wheel.wheelCollider.steerAngle = steer * maxSteerAngle; 
            }
        }
    }
}
