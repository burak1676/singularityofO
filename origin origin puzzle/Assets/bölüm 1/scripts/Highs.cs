using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highs : MonoBehaviour
{

    public Text Score;

    void Start()
    {
        Score.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void hesaplama()
    {
        if (astro_hareket.coins > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", astro_hareket.coins);
            Score.text = astro_hareket.coins.ToString();

        }

    }

}