using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public int Lap { get { return lap; } }

    [SerializeField] int lap = 0;
    [SerializeField] int checkpoint = -1;
    [SerializeField] int nextCheckpoint = 0;
    int checkpointCount;

    private void Start()
    {
        checkpointCount = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        Debug.Log(checkpointCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Checkpoint"))
        {
            int number = int.Parse(other.name);
            //Debug.Log("Wykryto checkpoint: " + number);

            if( number == nextCheckpoint )
            {
                checkpoint = number;
                if(checkpoint == 0)
                {
                    lap++;
                }
                nextCheckpoint++;
                nextCheckpoint = nextCheckpoint % checkpointCount;
            }
        }
    }
}
