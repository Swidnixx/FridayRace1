using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] spawnPos;

    public GameObject roomInfoPanel;
    public GameObject startRaceButton;
    public GameObject waitingText;

    int playerIndex;

    private void Awake()
    {
        RaceController.RaceStarted += OnRaceStarted;
    }

    void OnRaceStarted()
    {
        roomInfoPanel.SetActive(false);
    }

    private void Start()
    {
        playerIndex = PhotonNetwork.CurrentRoom.PlayerCount - 1;

        roomInfoPanel.SetActive(true);
        startRaceButton.SetActive(false);
        waitingText.SetActive(false);

        object[] instanceData = { 
            PlayerPrefs.GetString("Nick"),
            PlayerPrefs.GetFloat("R"), PlayerPrefs.GetFloat("G"), PlayerPrefs.GetFloat("B")
        };
        var car = PhotonNetwork.Instantiate(
            carPrefab.name, 
            spawnPos[playerIndex].position, spawnPos[playerIndex].rotation,
            0, instanceData
            );

        car.GetComponent<PlayerController>().enabled = true;
        GameObject.FindObjectOfType<CameraController>().SetCameraToCar(car.transform); // (!error) <-- CarObject but should be CarBody

        if(PhotonNetwork.IsMasterClient)
        {
            startRaceButton.SetActive(true);
        }
        else
        {
            waitingText.SetActive(true);
        }
    }
}
