using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveSupport : MonoBehaviour
{
    float carRolloverTime = 0;
    float carNotMovingTime = 0;
    Rigidbody rb;
    CheckpointController ckpController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ckpController = GetComponent<CheckpointController>();
    }

    private void Update()
    {
        AntiRollover();
        AntiStuck();
    }

    void AntiStuck()
    {
        if(rb.velocity.magnitude < 0.5f && RaceController.racePending)
        {
            carNotMovingTime += Time.deltaTime;
        }
        else
        {
            carNotMovingTime = 0;
        }

        if(carNotMovingTime > 3.5f)
        {
            Vector3 offset = transform.position - ckpController.LastCheckpoint.position;
            Vector2 carFromSpawn = new Vector2(offset.x, offset.z);
            if(carFromSpawn.magnitude > 1)
            {
                transform.position = ckpController.LastCheckpoint.position;
                transform.rotation = ckpController.LastCheckpoint.rotation;

                rb.velocity = Vector3.zero;
            }
            else
            {
                carNotMovingTime = 0;
            }
        }
    }

    void AntiRollover()
    {
        if (transform.up.y > 0.1)
        {
            carRolloverTime = 0;
        }
        else
        {
            carRolloverTime += Time.deltaTime;
        }

        if (carRolloverTime > 2)
        {
            transform.position += Vector3.up;
            transform.rotation = Quaternion.LookRotation(transform.forward);
        }
    }
}
