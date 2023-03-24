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

    public GameObject backLights;

    private void Start()
    {
        rb.centerOfMass = centerOfMass.localPosition;
    }

    public void Drive(float accel, float steer, float brake)
    {
        speed = rb.velocity.magnitude * 3.6f;
        EngineSound(accel);

        if (speed >= maxSpeed)
            accel = 0;

        if(brake != 0)
        {
            backLights.SetActive(true);
        }
        else
        {
            backLights.SetActive(false);
        }

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

    public AudioSource engineAudioSource;
    public float gearChangeTime = 5;
    public float minPitch = 0.55f;
    public float maxPitch = 1.1f;
    float accelTime;

    int currentGear = 1;
    void EngineSound( float accel )
    {
        if(speed < 20)
        {
            //accelTime = gearChangeTime / 2;
            currentGear = 1;
        }

        accel = Mathf.Abs(accel);

        if( accel > 0 )
        {
            accelTime += Time.deltaTime;
            accelTime = Mathf.Min(accelTime, gearChangeTime);
        }
        else
        {
            accelTime -= Time.deltaTime;
            accelTime = Mathf.Max( 0, accelTime );
        }

        float normalizedAccelTime = accelTime / gearChangeTime;
        engineAudioSource.pitch = Mathf.Lerp(minPitch, maxPitch, normalizedAccelTime);

        if( accelTime == 0 && currentGear > 1)
        {
            currentGear--;
            accelTime = gearChangeTime - 0.15f * gearChangeTime;
        }

        if( accelTime == gearChangeTime && currentGear < 4 )
        {
            currentGear++;
            accelTime = 0 + 0.15f * gearChangeTime;
        }
    }
}
