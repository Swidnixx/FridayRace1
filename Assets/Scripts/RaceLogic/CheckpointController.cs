using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public int Lap { get { return lap; } }
    public int Checkpoint {  get { return checkpoint; } }
    public Transform LastCheckpoint { get; private set; }

    [SerializeField] int lap = 0;
    [SerializeField] int checkpoint = -1;
    [SerializeField] int nextCheckpoint = 0;
    int checkpointCount;

    private void Start()
    {
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        checkpointCount = checkpoints.Length;
        foreach(var c in checkpoints)
        {
            if(c.name == "0")
            {
                LastCheckpoint = c.transform;
                break;
            }
        }
       // Debug.Log("Checkpoint Count: " + checkpointCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Checkpoint"))
        {
            int number = int.Parse(other.name);
            //Debug.Log("Wykryto checkpoint: " + number);

            //Zaliczono kolejny checkpoint
            if( number == nextCheckpoint )
            {
                LastCheckpoint = other.transform;
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
