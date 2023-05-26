using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DrivingScript ds;
    public DriveSupport dss;
    public GameObject backCamera;

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

    internal void ActivateLocally()
    {
        this.enabled = true;
        ds.enabled = true;
        dss.enabled = true;
        backCamera.SetActive(true);
    }
}
