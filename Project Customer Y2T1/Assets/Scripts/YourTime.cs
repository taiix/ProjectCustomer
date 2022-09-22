using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class YourTime : MonoBehaviour
{
    public TextMeshPro bestTime;
    TextMeshPro yourTime;

    private void Start()
    {
        yourTime = GetComponent<TextMeshPro>();
        yourTime.text = "Your Time: " + PlayerPrefs.GetFloat("Time").ToString("00:00");

        bestTime.text = "Best Time: " + PlayerPrefs.GetFloat("HighScore").ToString("00:00");

    }
}
