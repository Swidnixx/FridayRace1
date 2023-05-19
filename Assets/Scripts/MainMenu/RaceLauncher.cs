using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RaceLauncher : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI networkText;
    byte playersPerRoom = 4;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        PhotonNetwork.NickName = PlayerPrefs.GetString("Nick");

        PhotonNetwork.ConnectUsingSettings();
        networkText.text = "Connecting...\n";
    }

    public override void OnConnectedToMaster()
    {
        networkText.text += "Connected to Server.\n";
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        networkText.text += "Failed to join a room: \n"; //+ message + "; " + returnCode+"\n";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = playersPerRoom});
    }

    public override void OnJoinedRoom()
    {
        networkText.text += "Joined Room with " + PhotonNetwork.CurrentRoom.PlayerCount + " players.\n";
        PhotonNetwork.LoadLevel("TestTrack");
    }
}
