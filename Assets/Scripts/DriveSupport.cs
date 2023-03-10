using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveSupport : MonoBehaviour
{
    float timeNotOk = 0;

    public float transformY;
    private void Update()
    {
        transformY = transform.up.y;
        if (transform.up.y > 0.1)
        {
            timeNotOk = 0;
        }
        else
        {
            timeNotOk += Time.deltaTime;
        }

        if(timeNotOk > 2)
        {
            transform.position += Vector3.up;
            transform.rotation = Quaternion.LookRotation(transform.forward);
        }
    }
}
