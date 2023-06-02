using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        playerPositions[playerNumber].SetScore(lap, checkpoint);
    }

    private List<string> GetPlayerLeaderboard()
    {
        return playerPositions.OrderByDescending(p => p.Score).Select(p => p.Name).ToList();
    }

    class Player
    {
        public int Score => score;
        public string Name => name;

        string name;
        int score;

        public Player(string nickname)
        {
            name = nickname;
            score = 0;
        }


        internal void SetScore(int lap, int checkpoint)
        {
            score = lap * 1000 + checkpoint * 1;
        }
    }
}
