using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text highScore;

    private float timer;

    private float minutes;
    private float seconds;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore").ToString("00:00");
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        UpdateTimer(timer);
    }

    //Update the time and set the best time if the time is better than previous
    void UpdateTimer(float timer)
    {
        minutes = (int)timer / 60;
        seconds = timer % 60;

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timer > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", timer);
            highScore.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    //Using as a button
    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
    }

}
