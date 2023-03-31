using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DrivingScript ds;

    private void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        if(!RaceController.racePending)
        {
            accel = 0;
        }

        ds.Drive(accel, steer, brake);
    }
}
