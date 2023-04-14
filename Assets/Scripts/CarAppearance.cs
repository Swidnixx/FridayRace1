using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarAppearance : MonoBehaviour
{
    public string playerName = "player";
    public Color playerColor;
    public TextMeshProUGUI[] nameText;
    public MeshRenderer carRenderer;

    private void Start()
    {
        foreach (var text in nameText)
        {
            text.text = playerName;
            text.color = playerColor; 
        }
        carRenderer.material.color = playerColor;
    }
}
