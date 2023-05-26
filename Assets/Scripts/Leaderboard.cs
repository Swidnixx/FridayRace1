using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI[] texts;

    private void Start()
    {
        foreach(var t in texts)
        {
            t.text = "";
        }
    }

    private void Update()
    {
        List<string> players = GetPlayerLeaderboard();

        for(int i=0; i<players.Count; i++)
        {
            texts[i].text = players[i];
        }
    }

    static List<Player> playerPositions = new List<Player>();
    internal static int Register(string playerName)
    {
        playerPositions.Add(new Player(playerName));
        return playerPositions.Count - 1;
    }

    internal static void SetStatus(int playerNumber, int lap, int checkpoint)
    {
        throw new NotImplementedException();
    }

    class Player
    {
        string name;
        int score;
    }

}
