using Photon.Pun;
using System;
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

    GameObject localPlayer;
    int playerIndex;

    private void Awake()
    {
        RaceController.RaceStarted += OnRaceStarted;
    }

    private void OnDestroy()
    {
        RaceController.RaceStarted -= OnRaceStarted;
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
        var car = localPlayer = PhotonNetwork.Instantiate(
            carPrefab.name, 
            spawnPos[playerIndex].position, spawnPos[playerIndex].rotation,
            0, instanceData
            );

        car.GetComponent<PlayerController>().ActivateLocally();
        GameObject.FindObjectOfType<CameraController>().SetCameraToCar(car.transform.GetChild(0));

        if(PhotonNetwork.IsMasterClient)
        {
            startRaceButton.SetActive(true);
        }
        else
        {
            waitingText.SetActive(true);
        }
    }

    public void RespawnLocalPlayer()
    {
        var carBody = localPlayer.transform.GetChild(0);
        var rb = carBody.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        carBody.position = spawnPos[playerIndex].position;
        carBody.rotation = spawnPos[playerIndex].rotation;

        roomInfoPanel.SetActive(true);
        if (PhotonNetwork.IsMasterClient)
        {
            startRaceButton.SetActive(true);
        }
        else
        {
            waitingText.SetActive(true);
        }
    }
}
