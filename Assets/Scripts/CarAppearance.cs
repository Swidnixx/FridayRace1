using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Photon.Pun;

public class CarAppearance : MonoBehaviourPunCallbacks
{
    public CheckpointController ckpController;
    public TextMeshProUGUI[] nameText;
    public MeshRenderer carRenderer;

    string playerName = "player";
    Color playerColor;
    int playerNumber;

    private void Start()
    {
        if (photonView.IsMine)
        {
            playerName = PlayerPrefs.GetString("Nick");
            playerColor = new Color(PlayerPrefs.GetFloat("R"), PlayerPrefs.GetFloat("G"), PlayerPrefs.GetFloat("B")); 
        }
        else
        {
            object[] instanceData = photonView.InstantiationData;
            playerName = (string)instanceData[0];
            playerColor = new Color( (float)instanceData[1], (float)instanceData[2], (float)instanceData[3] );
        }

        foreach (var text in nameText)
        {
            text.text = playerName;
            text.color = playerColor; 
        }
        carRenderer.material.color = playerColor;

        //Leaderboard register
        playerNumber = Leaderboard.Register(playerName);
    }

    private void Update()
    {
        Leaderboard.SetStatus( playerNumber, ckpController.Lap, ckpController.Checkpoint);
    }
}
