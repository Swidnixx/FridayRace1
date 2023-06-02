using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceController : MonoBehaviourPunCallbacks
{
    public static event Action RaceStarted;

    public static bool racePending;
    public readonly static int totalLaps = 1;

    public int timer = 3;

    public GameObject startPanel;
    public TextMeshProUGUI startText;
    public GameObject finishPanel;

    public PlayerSpawner playerSpawner;
    CheckpointController[] controllers;

    public void StartRaceButton()
    {
        photonView.RPC( nameof(StartRace), RpcTarget.All, null);
        PhotonNetwork.CurrentRoom.IsOpen = false;
    }

    [PunRPC]
    void StartRace()
    {
        timer = 3;
        RaceStarted?.Invoke();

        startPanel.SetActive(true);
        finishPanel.SetActive(false);

        controllers = FindObjectsOfType<CheckpointController>();
        InvokeRepeating( nameof(CountDown), 1, 1 );
        startText.text = timer.ToString();
    }

    void CountDown()
    {
        timer--;
        startText.text = timer.ToString();
        if(timer < 1)
        {
            CancelInvoke();
            racePending = true;

            startText.text = "START!";
            Invoke(nameof(DisableStartUI), 1);
        }
    }
    void DisableStartUI()
    {
        startPanel.SetActive(false);
    }

    private void LateUpdate()
    {
        if (!racePending) return;

        int finishers = 0;

        foreach(var c in controllers)
        {
            if (c.Lap > totalLaps)
                finishers++;
        }

        if( finishers == controllers.Length )
        {
            FinishRace();
        }
    }

    private void FinishRace()
    {
        finishPanel.SetActive(true);
        racePending = false;
    }

    public void RestartRace()
    {
        photonView.RPC(nameof(Respawn), RpcTarget.All, null);
    }

    [PunRPC]
    void Respawn()
    {
        finishPanel.SetActive(false);
        playerSpawner.RespawnLocalPlayer();

        foreach (var c in controllers)
        {
            c.Reset();
        } 
    }
}
