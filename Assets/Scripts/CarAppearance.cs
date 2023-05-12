using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CarAppearance : MonoBehaviour
{
    public TextMeshProUGUI[] nameText;
    public MeshRenderer carRenderer;

    string playerName = "player";
    Color playerColor;
    int playerNumber;

    private void Start()
    {
        if (playerNumber == 0)
        {
            playerName = PlayerPrefs.GetString("Nick");
            playerColor = new Color(PlayerPrefs.GetFloat("R"), PlayerPrefs.GetFloat("G"), PlayerPrefs.GetFloat("B")); 
        }
        else
        {
            playerName = "Random" + playerNumber;
            playerColor = Color.white;
        }

        foreach (var text in nameText)
        {
            text.text = playerName;
            text.color = playerColor; 
        }
        carRenderer.material.color = playerColor;
    }

    public void SetPlayerNumber(int number)
    {
        playerNumber = number;
    }
}
