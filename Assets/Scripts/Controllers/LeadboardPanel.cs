using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeadboardPanel : MonoBehaviour
{
    public List<TextMeshProUGUI> placesText;

    private void LateUpdate()
    {
        List<string> places = Leaderboard.GetPlaces();

        for(int i = 0; i< placesText.Count; i++)
        {
            if (i < places.Count)
            {
                placesText[i].text = places[i];
            }
            else
                placesText[i].text = "";
        }
    }
}

public struct Car
{

}

public class Leaderboard
{
    static Dictionary<int, Car> board = new Dictionary<int, Car>();

    public static List<string> GetPlaces()
    {
        throw new NotImplementedException();
    }
}

