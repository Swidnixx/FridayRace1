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
        if(PlayerPrefs.HasKey("Nick"))
        {
            SetNickname( PlayerPrefs.GetString("Nick") );
        }
        else
        {
            SetNickname("Player");
        }

        color = new Color(
            sliderR.value = PlayerPrefs.GetFloat("R"),
            sliderG.value = PlayerPrefs.GetFloat("G"),
            sliderB.value = PlayerPrefs.GetFloat("B")
            );
        OnColorChanged(0);

        sliderR.onValueChanged.AddListener( OnColorChanged );
        sliderG.onValueChanged.AddListener( OnColorChanged );
        sliderB.onValueChanged.AddListener( OnColorChanged );
    }

    private void OnColorChanged(float value)
    {
        color = new Color(sliderR.value, sliderG.value, sliderB.value);
        carRenderer.material.color = color;

        PlayerPrefs.SetFloat("R", color.r);
        PlayerPrefs.SetFloat("G", color.g);
        PlayerPrefs.SetFloat("B", color.b);
    }

    public void SetNickname(string nickname)
    {
        nicknameText.text = nickname;
        PlayerPrefs.SetString("Nick", nickname);
    }

    public RaceLauncher launcher;
    public void StartGame()
    {
        launcher.Connect();
    }
}
