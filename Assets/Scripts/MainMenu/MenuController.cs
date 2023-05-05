using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI nicknameText;
    public Renderer carRenderer;

    public Slider sliderR;
    public Slider sliderG;
    public Slider sliderB;

    Color color;

    private void Start()
    {
        sliderR.onValueChanged.AddListener( OnColorChanged );
        sliderG.onValueChanged.AddListener( OnColorChanged );
        sliderB.onValueChanged.AddListener( OnColorChanged );
    }

    private void OnColorChanged(float value)
    {
        color = new Color(sliderR.value, sliderG.value, sliderB.value);
        carRenderer.material.color = color;
    }

    public void SetNickname(string nickname)
    {
        nicknameText.text = nickname;
    }
}
