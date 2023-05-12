using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] spawnPos;
    public int playerCount = 4;

    private void Start()
    {
        for(int i=0; i<playerCount; i++)
        {
            var car = Instantiate(carPrefab, spawnPos[i].position, spawnPos[i].rotation);
            car.GetComponent<CarAppearance>().SetPlayerNumber(i);
            if(i == 0)
            {
                car.GetComponent<PlayerController>().enabled = true;
                GameObject.FindObjectOfType<CameraController>().SetCameraToCar(car.transform);
            }
        }
    }
}
