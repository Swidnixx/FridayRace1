using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLeaderboardPlayer : MonoBehaviour
{
    void Start()
    {
        int id = Leaderboard.Register("TestGuy");
        Leaderboard.SetStatus(id, 1, 3);

        int id2 = Leaderboard.Register("TestGuy2");
        Leaderboard.SetStatus(id2, 1, 5);

        int id3 = Leaderboard.Register("TestGuy3");
        Leaderboard.SetStatus(id3, 1, 6);
    }
}
